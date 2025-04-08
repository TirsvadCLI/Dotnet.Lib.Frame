[![NuGet Downloads][nuget-shield]][nuget-url]
[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
[![MIT License][license-shield]][license-url]
[![LinkedIn][linkedin-shield]][linkedin-url]

# Frame handler
Frame tool for C# console applications.

[![Screenshot 1][Screenshot1]][ScreenShot1-url][![Screenshot 2][Screenshot2]][ScreenShot2-url][![Screenshot 3][Screenshot3]][ScreenShot3-url][![Screenshot 4][Screenshot4]][ScreenShot4-url]

## Table of Contents
- [About The Project](#about-the-project)  
- [How to get started](#how-to-get-started)  
    - [Installation](#installation)  
- [Public Methods](#public-methods)  
    - [Constructors](#constructors)  
    - [Methods](#methods)  
- [Example](#example)  
- [Contributing](#contributing)  
- [Bug / Issue Reporting](#bug--issue-reporting)  
- [License](#license)  
- [Contact](#contact)

## About The Project

Frame tool for C# console applications. Create a frame with text inside. Frame can be centered to windows.

Frame can be filled with a character and colored.

## How to get started

Nuget package: https://www.nuget.org/packages/TirsvadCLI.Frame/

### Installation

```sh
dotnet add package TirsvadCLI.Frame
```


## Example

In the [example](https://github.com/TirsvadCLI/Dotnet.Tool.Frame/blob/main/src/Example/Example.cs) you can see how to use the AnsiCode class.

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
  Navigate to the [GitHub Issues page](https://github.com/TirsvadCLI/CSharp.Tool.Frame/issues).  

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

<!-- MARKDOWN LINKS & IMAGES -->
[contributors-shield]: https://img.shields.io/github/contributors/TirsvadCLI/CSharp.Tool.Frame?style=for-the-badge
[contributors-url]: https://github.com/TirsvadCLI/CSharp.Tool.Frame/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/TirsvadCLI/CSharp.Tool.Frame?style=for-the-badge
[forks-url]: https://github.com/TirsvadCLI/CSharp.Tool.Frame/network/members
[stars-shield]: https://img.shields.io/github/stars/TirsvadCLI/CSharp.Tool.Frame?style=for-the-badge
[stars-url]: https://github.com/TirsvadCLI/CSharp.Tool.Frame/stargazers
[issues-shield]: https://img.shields.io/github/issues/TirsvadCLI/CSharp.Tool.Frame?style=for-the-badge
[issues-url]: https://github.com/TirsvadCLI/CSharp.Tool.Frame/issues
[license-shield]: https://img.shields.io/github/license/TirsvadCLI/CSharp.Tool.Frame?style=for-the-badge
[license-url]: https://github.com/TirsvadCLI/CSharp.Tool.Frame/blob/master/LICENSE
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=for-the-badge&logo=linkedin&colorB=555
[linkedin-url]: https://www.linkedin.com/in/jens-tirsvad-nielsen-13b795b9/
[nuget-shield]: https://img.shields.io/nuget/dt/TirsvadCLI.Frame?style=for-the-badge
[nuget-url]: https://www.nuget.org/packages/TirsvadCLI.Frame/

[Screenshot1]: https://raw.githubusercontent.com/TirsvadCLI/Dotnet.Tool.Frame/master/images/Screenshot1-small.png
[ScreenShot1-url]: https://github.com/TirsvadCLI/Dotnet.Tool.Frame/blob/main/images/Screenshot1.png
[Screenshot2]: https://raw.githubusercontent.com/TirsvadCLI/Dotnet.Tool.Frame/master/images/Screenshot2-small.png
[ScreenShot2-url]: https://github.com/TirsvadCLI/Dotnet.Tool.Frame/blob/main/images/Screenshot2.png
[Screenshot3]: https://raw.githubusercontent.com/TirsvadCLI/Dotnet.Tool.Frame/master/images/Screenshot3-small.png
[ScreenShot3-url]: https://github.com/TirsvadCLI/Dotnet.Tool.Frame/blob/main/images/Screenshot3.png
[Screenshot4]: https://raw.githubusercontent.com/TirsvadCLI/Dotnet.Tool.Frame/master/images/Screenshot4-small.png
[ScreenShot4-url]: https://github.com/TirsvadCLI/Dotnet.Tool.Frame/blob/main/images/Screenshot4.png



