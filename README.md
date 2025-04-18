[![NuGet Downloads][nuget-shield]][nuget-url][![Contributors][contributors-shield]][contributors-url][![Forks][forks-shield]][forks-url][![Stargazers][stars-shield]][stars-url][![Issues][issues-shield]][issues-url][![License][license-shield]][license-url][![LinkedIn][linkedin-shield]][linkedin-url]

# ![logo][logo] Frame libary
Frame library for C# console applications.

[![screenShot 1][screenShot1]][screenShot1-url][![screenShot 2][screenShot2]][screenShot2-url][![screenShot 3][screenShot3]][screenShot3-url][![screenShot 4][screenShot4]][screenShot4-url]

## Table of Contents 
- [Overview](#overview)
- [Features](#features)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
    - [Install via NuGet Package Manager Console](#install-via-nuget-package-manager-console)
    - [Install via Visual Studio NuGet Package Manager](#install-via-visual-studio-nuget-package-manager)
    - [Install via .NET CLI](#install-via-dotnet-cli)
    - [Clone the repo](#clone-the-repo)
  - [Example Usage](#example-usage)
- [Contributing](#contributing)
- [Bug / Issue Reporting](#bug--issue-reporting)
- [License](#license)
- [Contact](#contact)
- [Acknowledgments](#acknowledgments)

## Overview
The Frame library is a C# library designed to create customizable frames in console applications. It allows developers to easily add borders, colors, and text to their console output, enhancing the visual appeal of command-line interfaces.

## Features
- **Customizable Borders**: Choose from various border characters to create unique frames.
- **Color Support**: Set foreground and background colors for both the frame and text.

## Getting Started
To get started with the Frame library, you will need to install the library in your .NET project. You can do this using NuGet Package Manager or by adding the package reference directly to your project file.

### Prerequisites
- .NET 9.0 or later

## Installation
To use the Frame library, you will need to download and then add a reference to the library in your project. Follow the instructions below to install the library and get started.

#### Install via NuGet Package Manager Console
You can install the Form library using the NuGet Package Manager Console. Open the console and run the following command:
```bash
Install-Package TirsvadCLI.Frame
```

#### Install via Visual Studio NuGet Package Manager
1. Open your project in Visual Studio.
2. Right-click on your project in the Solution Explorer and select "Manage NuGet Packages".
3. Search for "TirsvadCLI.Frame" in the NuGet Package Manager.
4. Click "Install" to add the library to your project. 

#### Install via .NET CLI
You can also install the Frame library using the .NET CLI. Open a terminal and run the following command:
```bash
dotnet add package TirsvadCLI.Frame
```

#### Clone the repo
![Repo size][repos-size-shield]

If you want to clone the repository and build the library from source, you can do so using Git. Make sure you have Git installed on your machine. Then, run the following command in your terminal:

```bash
git clone git@github.com:TirsvadCLI/Dotnet.Lib.Frame.git
```

## Example

In the [example][example-url] you can see how to use the Frame class.

## Public Methods
The `Frame` class provides several methods to create and customize frames in console applications. 
Below is a list of the public methods and their descriptions:

### Constructors
1. **`Frame()`**
   - Initializes a frame with default dimensions, border characters, and colors.

2. **`Frame(int windowWidth, int windowHeight, int? frameWidth = null, int? frameHeight = null, char leftTop = '╔', char rightTop = '╗', char leftBottom = '╚', char rightBottom = '╝', char horizontal = '═', char vertical = '║')`**
   - Creates a frame with specified dimensions and optional custom border characters.

3. **`Frame(int windowWidth, int windowHeight, string[] frameText, int? frameWidth = null, int? frameHeight = null, char leftTop = '╔', char rightTop = '╗', char leftBottom = '╚', char rightBottom = '╝', char horizontal = '═', char vertical = '║')`**
   - Creates a frame with text inside and optional custom dimensions and border characters.

### Methods
1. **`SetStartPosition((int Left, int Top) startPosition)`**
   - Sets the starting position of the frame on the console.

2. **`SetColorBg(ConsoleColor color)`**
   - Sets the background color for both the frame and text.

3. **`SetColorFg(ConsoleColor color)`**
   - Sets the foreground color for both the frame and text.

4. **`SetTextColorBg(ConsoleColor color)`**
   - Sets the background color of the text inside the frame.

5. **`SetTextColorFg(ConsoleColor color)`**
   - Sets the foreground color of the text inside the frame.

6. **`SetFrameColorBg(ConsoleColor color)`**
   - Sets the background color of the frame.

7. **`SetFrameColorFg(ConsoleColor color)`**
   - Sets the foreground color of the frame.

8. **`SetFrameText(string title)`**
   - Sets a single line of text inside the frame.

9. **`SetFrameText(List<string> title)`**
   - Sets multiple lines of text inside the frame.

10. **`Render(bool center = false)`**
    - Renders the frame on the console. If `center` is `true`, the frame is centered on the screen.

11. **`FrameText(ICollection<string> texts, bool centerText = false)`**
    - Frames the provided text and optionally centers it.

12. **`CenterText(string text, int width)`**
    - Centers a single line of text within the specified width.

These methods allow you to create visually appealing and customizable frames for console applications. For usage examples, refer to the [Example](#example) section.

## Contributing
Contributions are what make the open-source community such an amazing place to learn, inspire, and create. Any contributions you make are **greatly appreciated**.

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## Bug / Issue Reporting  
If you encounter a bug or have an issue to report, please follow these steps:  

1. **Go to the Issues Page**  
  Navigate to the [GitHub Issues page](https://github.com/TirsvadCLI/Dotnet.Lib.Frame/issues).  

2. **Click "New Issue"**  
  Click the green **"New Issue"** button to create a new issue.  

3. **Provide Details**  
  - **Title**: Write a concise and descriptive title for the issue.  
  - **Description**: Include the following details:  
    - Steps to reproduce the issue.  
    - Expected behavior.  
    - Actual behavior.  
    - Environment details (e.g., OS, .NET version, etc.).  
  - **Attachments**: Add screenshots, logs, or any other relevant files if applicable.  

4. **Submit the Issue**  
  Once all details are filled in, click **"Submit new issue"** to report it.  

Your feedback is valuable and helps improve the project!

## License
Distributed under the GPL-3.0 [License][license-url].

## Contact
Jens Tirsvad Nielsen - [LinkedIn][linkedin-url]

## Acknowledgements  
- [Microsoft .NET](https://dotnet.microsoft.com/) - The framework used for this project.  
- [NuGet](https://www.nuget.org/) - For package management and distribution.  
- [GitHub](https://github.com/) - For version control and collaboration.  
- [Shields.io](https://shields.io/) - For creating the badges used in this README.  
- [Visual Studio](https://visualstudio.microsoft.com/) - For providing a powerful IDE for .NET development.
- [Stack Overflow](https://stackoverflow.com/) - For community support and answers to programming questions.
- [Contributors](https://github.com/TirsvadCLI/Dotnet.Lib.Frame/graphs/contributors) - Thanks to all contributors who have helped improve this project.

<!-- MARKDOWN LINKS & IMAGES -->
[contributors-shield]: https://img.shields.io/github/contributors/TirsvadCLI/Dotnet.Lib.Frame?style=for-the-badge
[contributors-url]: https://github.com/TirsvadCLI/Dotnet.Lib.Frame/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/TirsvadCLI/Dotnet.Lib.Frame?style=for-the-badge
[forks-url]: https://github.com/TirsvadCLI/Dotnet.Lib.Frame/network/members
[stars-shield]: https://img.shields.io/github/stars/TirsvadCLI/Dotnet.Lib.Frame?style=for-the-badge
[stars-url]: https://github.com/TirsvadCLI/Dotnet.Lib.Frame/stargazers
[issues-shield]: https://img.shields.io/github/issues/TirsvadCLI/Dotnet.Lib.Frame?style=for-the-badge
[issues-url]: https://github.com/TirsvadCLI/Dotnet.Lib.Frame/issues
[license-shield]: https://img.shields.io/github/license/TirsvadCLI/Dotnet.Lib.Frame?style=for-the-badge
[license-url]: https://github.com/TirsvadCLI/Dotnet.Lib.Frame/blob/master/LICENSE
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=for-the-badge&logo=linkedin&colorB=555
[linkedin-url]: https://www.linkedin.com/in/jens-tirsvad-nielsen-13b795b9/
[repos-size-shield]: https://img.shields.io/github/repo-size/TirsvadCLI/Dotnet.Lib.Frame?style=for-the-badg

[nuget-shield]: https://img.shields.io/nuget/dt/TirsvadCLI.Frame?style=for-the-badge
[nuget-url]: https://www.nuget.org/packages/TirsvadCLI.Frame/

[logo]: https://raw.githubusercontent.com/TirsvadCLI/Dotnet.Lib.Frame/main/image/logo/32x32/logo.png

[screenShot1]: https://raw.githubusercontent.com/TirsvadCLI/Dotnet.Tool.Frame/master/image/Screenshot1-small.png
[screenShot1-url]: https://github.com/TirsvadCLI/Dotnet.Tool.Frame/blob/main/image/Screenshot1.png
[screenShot2]: https://raw.githubusercontent.com/TirsvadCLI/Dotnet.Tool.Frame/master/image/Screenshot2-small.png
[screenShot2-url]: https://github.com/TirsvadCLI/Dotnet.Tool.Frame/blob/main/image/Screenshot2.png
[screenShot3]: https://raw.githubusercontent.com/TirsvadCLI/Dotnet.Tool.Frame/master/image/Screenshot3-small.png
[screenShot3-url]: https://github.com/TirsvadCLI/Dotnet.Tool.Frame/blob/main/image/Screenshot3.png
[screenShot4]: https://raw.githubusercontent.com/TirsvadCLI/Dotnet.Tool.Frame/master/image/Screenshot4-small.png
[screenShot4-url]: https://github.com/TirsvadCLI/Dotnet.Tool.Frame/blob/main/image/Screenshot4.png

[example-url]: https://raw.githubusercontent.com/TirsvadCLI/Dotnet.Lib.Frame/master/src/Example/Examples.cs


