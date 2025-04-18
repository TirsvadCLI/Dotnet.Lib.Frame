param(
    # Path to the project file; adjust this default value if needed.  
    [string]$ProjectFilePath = "$PSScriptRoot/src/Frame/TirsvadCLI.Frame.csproj",
    # Path to the NuGet API key for authentication.  
    [string]$NuGetApiKey = "$env:NugetTirsvadCLI",  # Replace with your actual API key or set it in the environment variable.
    # NuGet source URL (default is nuget.org).  
    [string]$NuGetSource = "https://api.nuget.org/v3/index.json",
    # Path to the certificate file (PFX format) for signing
    [string]$CertificatePath = "$PSScriptRoot/../../../cert/NugetCertTirsvad/Tirsvad.pfx",
    # Password for the certificate file
    [string]$CertificatePassword = "$env:CertTirsvadPassword", # Replace with your actual password or set it in the environment variable.
    # Is this a NuGet package?
    [switch]$IsNuGetPackage = $true,
    # Selfsigned nuget should be off as Nuget.org donnot accept selfsigned packages
    [switch]$SelfSignedNuGet = $true,
    # Path to signtool.exe
    [string]$SignToolPath = "C:\Program Files (x86)\Windows Kits\10\bin\10.0.26100.0\x64\signtool.exe"
)

function ExitWaitForKey {
    param(
        [string]$ErrorMessage = ""
    )

    if ($ErrorMessage) {
        Write-Error $ErrorMessage
    }

    Write-Host "Press any key to continue..."
    $null = $Host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown")

    exit 1
}

# Ensure the script is running as an administrator.
if (-not (New-Object Security.Principal.WindowsPrincipal([Security.Principal.WindowsIdentity]::GetCurrent())).IsInRole([Security.Principal.WindowsBuiltInRole]::Administrator)) {
    Write-Output "Elevating script to run as administrator..."
    $arguments = @('-File', $MyInvocation.MyCommand.Source)
    if ($args) {
        $arguments += $args
    }
    Start-Process -FilePath 'powershell' -ArgumentList $arguments -Verb RunAs
    exit
}

# Verify the project file exists.
if (!(Test-Path $ProjectFilePath)) {
    ExitWaitForKey -ErrorMessage "Project file does not exist at path: $ProjectFilePath"
}

# Load the project file as XML.
try {
    [xml]$projXml = Get-Content $ProjectFilePath -ErrorAction Stop
} catch {
    ExitWaitForKey -ErrorMessage "Failed to load the project file. Ensure the file exists and is accessible."
}

# Build the project in Release mode.
Write-Output "Building the project in Release mode..."
& dotnet build $ProjectFilePath -c Release
if ($LASTEXITCODE -ne 0) {
    ExitWaitForKey -ErrorMessage "Build failed. Please check the output for errors."
}
Write-Output "Build succeeded in Release mode."

if ($IsNuGetPackage) {
    if ($SelfSignedNuGet) {
        # Selfigned Nuget is not supported by nuget.org
        Write-Output "Self-signed NuGet packages are not supported by nuget.org."
    } else {
        # Pack the project to create a NuGet package.
        Write-Output "Packing the project to create a NuGet package..."
        & dotnet pack $ProjectFilePath -c Release --no-build
        if ($LASTEXITCODE -ne 0) {
            ExitWaitForKey -ErrorMessage "Packing failed. Please check the output for errors."
        }
        Write-Output "NuGet package created successfully."

        # Find the generated .nupkg file.
        $projectDirectory = Split-Path -Path $ProjectFilePath -Parent
        $packagePath = Get-ChildItem -Path "$projectDirectory\bin\Release" -Filter *.nupkg | Select-Object -ExpandProperty FullName
        if (-not $packagePath) {
            ExitWaitForKey -ErrorMessage "NuGet package not found in the expected directory."
        }
        Write-Output "Found NuGet package: $packagePath"

        # Sign the NuGet package with the certificate.
        Write-Output "Signing the NuGet package with the certificate..."
        & dotnet nuget sign $packagePath `
            --certificate-path $CertificatePath `
            --certificate-password $CertificatePassword `
            --timestamper "http://timestamp.digicert.com"
        if ($LASTEXITCODE -ne 0) {
            ExitWaitForKey -ErrorMessage "Failed to sign the NuGet package. Please check the output for errors."
        }
        Write-Output "NuGet package signed successfully."

        # Push the NuGet package to the specified source.
        Write-Output "Pushing the NuGet package to $NuGetSource..."
        & dotnet nuget push $packagePath --api-key $NuGetApiKey --source $NuGetSource
        if ($LASTEXITCODE -ne 0) {
            ExitWaitForKey -ErrorMessage "Failed to push the NuGet package. Please check the output for errors."
        }
        Write-Output "NuGet package uploaded successfully to $NuGetSource."
    }
} else {
    # Find the generated .exe file.
    $projectDirectory = Split-Path -Path $ProjectFilePath -Parent
    Write-Output "Project directory: $projectDirectory"
    Write-Output "Locating the .exe file in the Release directory..."
    # Find the first PropertyGroup element that contains a TargetFramework element.
    $propertyGroup = $projXml.Project.PropertyGroup | Where-Object { $_.TargetFramework }
    if ($propertyGroup) {
        $exePath = Get-ChildItem -Path "$projectDirectory\bin\Release" -Filter *.exe | Select-Object -ExpandProperty FullName
    } else {
        # If no TargetFramework is found, assume the default path.
        $exePath = Get-ChildItem -Path "$projectDirectory\bin\Release\$propertyGroup.TargetFramework" -Filter *.exe | Select-Object -ExpandProperty FullName
    }
    $exePath = Get-ChildItem -Path "$projectDirectory\bin\Release\net9.0" -Filter *.exe | Select-Object -ExpandProperty FullName
    if (-not $exePath) {
        ExitWaitForKey -ErrorMessage "Executable file not found in the expected directory."
    }
    Write-Output "Found executable: $exePath"

    # Check if signtool.exe is available
    #$SignToolPath = Get-Command signtool.exe -ErrorAction SilentlyContinue
    if (-not $SignToolPath) {
        ExitWaitForKey -ErrorMessage "signtool.exe not found. Ensure it is installed and available in the system's PATH."
    }

    # Sign the .exe file with the certificate.
    Write-Output "Signing the executable with the certificate..."
    $signOutput = & $SignToolPath sign /fd sha256 /f $CertificatePath /p $CertificatePassword /t http://timestamp.digicert.com $exePath 2>&1
    Write-Output "SignTool Output: $signOutput"
    if ($LASTEXITCODE -ne 0) {
        Write-Error "Failed to sign the executable. Output:"
        Write-Output $signOutput
        ExitWaitForKey -ErrorMessage "Failed to sign the executable. Please check the output for errors."
    }
    Write-Output "Executable signed successfully."
}

# Find the first PropertyGroup element that contains a VersionPrefix element.
$propertyGroup = $projXml.Project.PropertyGroup | Where-Object { $_.VersionPrefix }
if (-not $propertyGroup) {
    ExitWaitForKey -ErrorMessage "No <VersionPrefix> element found in the project file."
}

# Get the old version string.
$oldVersion = $propertyGroup.VersionPrefix
Write-Output "Current version: $oldVersion"

# Validate and increment the version.
$versionParts = $oldVersion -split "\."
if ($versionParts.Length -ne 3 -or -not ($versionParts | ForEach-Object { $_ -match '^\d+$' })) {
    ExitWaitForKey -ErrorMessage "Version format is not recognized. Expected format: Major.Minor.Build (e.g., 0.1.0)"
}

$major = $versionParts[0]
$minor = $versionParts[1]
$build = [int]$versionParts[2]
$build++

$newVersion = "$major.$minor.$build"
$propertyGroup.VersionPrefix = $newVersion
Write-Output "Updated version: $newVersion"

# Save the updated project file.
try {
    $projXml.Save($ProjectFilePath)
    Write-Output "Project file updated with new version."
} catch {
    ExitWaitForKey -ErrorMessage "Failed to save the updated project file."
}

# Commit and push the changes using Git.
#try {
#    Write-Output "Staging changes..."
#    cd $PSScriptRoot
#    & git add $ProjectFilePath

#    Write-Output "Creating commit..."
#    & git commit -m "Bump build number to $newVersion"

#    Write-Output "Pushing to remote repository..."
#    & git push
#} catch {
#    ExitWaitForKey -ErrorMessage "Failed to commit and push changes to the repository."
#}

Start-Sleep -Seconds 3000
