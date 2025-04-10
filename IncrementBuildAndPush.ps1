param(
    # Path to the project file; adjust this default value if needed.  
    [string]$ProjectFilePath = "$PSScriptRoot\src\Frame\TirsvadCLI.Frame.csproj",
    # Path to the NuGet API key for authentication.  
    [string]$NuGetApiKey = "$env:NugetTirsvadCLI",  # Replace with your actual API key or set it in the environment variable.
    # NuGet source URL (default is nuget.org).  
    [string]$NuGetSource = "https://api.nuget.org/v3/index.json",
    # Path to the certificate file (PFX format) for signing
    [string]$CertificatePath = "..\..\..\cert\NugetCertTirsvad\Tirsvad.pfx",
    # Password for the certificate file
    [string]$CertificatePassword = "$env:CertTirsvadPassword" # Replace with your actual password or set it in the environment variable.
) 

if (!
    #current role
    (New-Object Security.Principal.WindowsPrincipal(
        [Security.Principal.WindowsIdentity]::GetCurrent()
    #is admin?
    )).IsInRole(
        [Security.Principal.WindowsBuiltInRole]::Administrator
    )
) {
    #elevate script and exit current non-elevated runtime
    Start-Process `
        -FilePath 'powershell' `
        -ArgumentList (
            #flatten to single array
            '-File', $MyInvocation.MyCommand.Source, $args `
            | %{ $_ }
        ) `
        -Verb RunAs
    exit
}

# Verify the project file exists.
if (!(Test-Path $ProjectFilePath)) {
    Write-Error "Project file does not exist at path: $ProjectFilePath"
    exit 1
}

# Load the project file as XML.
[xml]$projXml = Get-Content $ProjectFilePath

# Find the first PropertyGroup element that contains a VersionPrefix element.
$propertyGroup = $projXml.Project.PropertyGroup | Where-Object { $_.VersionPrefix }
if (-not $propertyGroup) {
    Write-Error "No <VersionPrefix> element found in the project file."
    exit 1
}

# Get the old version string.
$oldVersion = $propertyGroup.VersionPrefix
Write-Output "Current version: $oldVersion"

# Assume the version is in the format Major.Minor.Build (e.g., 0.1.0)
$versionParts = $oldVersion -split "\."
if ($versionParts.Length -ne 3) {
    Write-Error "Version format is not recognized. Expected format: Major.Minor.Build (e.g., 0.1.0)"
    exit 1
}

# Convert the Build part (third component) to an integer and increment it.
$major = $versionParts[0]
$minor = $versionParts[1]
$build = [int]$versionParts[2]
$build++

# Create a new version string.
$newVersion = "$major.$minor.$build"
$propertyGroup.VersionPrefix = $newVersion
Write-Output "Updated version: $newVersion"

# Save the updated project file.
$projXml.Save($ProjectFilePath)
Write-Output "Project file updated with new version."

# Now commit and push the changes using Git.
Write-Output "Staging changes..."
& git add $ProjectFilePath

Write-Output "Creating commit..."
& git commit -m "Bump build number to $newVersion"

Write-Output "Pushing to remote repository..."
& git push

Write-Output "Build number updated, committed, and pushed successfully."



# Build the project in Release mode.
Write-Output "Building the project in Release mode..."
& dotnet build $ProjectFilePath -c Release

if ($LASTEXITCODE -ne 0) {
    Write-Error "Build failed. Please check the output for errors."
    exit 1
}
Write-Output "Build succeeded in Release mode."

# Pack the project to create a NuGet package.
Write-Output "Packing the project to create a NuGet package..."
& dotnet pack $ProjectFilePath -c Release --no-build

if ($LASTEXITCODE -ne 0) {
    Write-Error "Packing failed. Please check the output for errors."
    exit 1
}
Write-Output "NuGet package created successfully."


# Find the generated .nupkg file.
$projectDirectory = Split-Path -Path $ProjectFilePath -Parent
$packagePath = Get-ChildItem -Path $projectDirectory\bin\Release -Filter *.nupkg | Select-Object -ExpandProperty FullName

if (-not $packagePath) {
    Write-Error "NuGet package not found in the expected directory."
    exit 1
}
Write-Output "Found NuGet package: $packagePath"

# Sign the NuGet package with the certificate
Write-Output "Signing the NuGet package with the certificate..."
& dotnet nuget sign $packagePath `
    --certificate-path $CertificatePath `
    --certificate-password $CertificatePassword `
    --timestamper "http://timestamp.digicert.com"

if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to sign the NuGet package. Please check the output for errors."
    exit 1
}
Write-Output "NuGet package signed successfully."

# Push the NuGet package to the specified source.
Write-Output "Pushing the NuGet package to $NuGetSource..."
& dotnet nuget push $packagePath --api-key $NuGetApiKey --source $NuGetSource #TODO

if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to push the NuGet package. Please check the output for errors."
    exit 1
}
Write-Output "NuGet package uploaded successfully to $NuGetSource."

