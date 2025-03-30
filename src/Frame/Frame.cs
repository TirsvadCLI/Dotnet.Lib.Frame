namespace TirsvadCLI.Frame;

public class Frame
{
    private int _windowWidth; // Width of the frame
    private int _windowHeight; // Height of the frame
    private int _frameWidth; // Width of the frame. Can be different from windowWidth when using center frame
    private int _frameHeight; // Height of the frame. Can be different from windowHeight when using center frame
    private int _startX = 0; // Start position of the frame on the x-axis
    private int _startY = 0; // Start position of the frame on the y-axis
    private char _leftTop; // Character for the top-left corner
    private char _rightTop; // Character for the top-right corner
    private char _leftBottom; // Character for the bottom-left corner
    private char _rightBottom; // Character for the bottom-right corner
    private char _horizontal; // Character for the horizontal borders
    private char _vertical; // Character for the vertical borders

    private List<string>? _frameText; // Title of the frame

    private ConsoleColor FrameColorBg = ConsoleColor.Black; // Background color of the frame
    private ConsoleColor FrameColorFg = ConsoleColor.White; // Foreground color of the frame

    /// <summary>
    /// Full screen frame with default border characters.
    /// Default the frame will be same size as window if not specified.
    /// </summary>
    /// <param name="windowWidth">The windowWidth of the frame.</param>
    /// <param name="windowHeight">The windowHeight of the frame.</param>
    /// <param name="frameWidth">Optional: The width of the frame.</param>
    /// <param name="frameHeight">Optional: The height of the frame.</param>
    /// <param name="leftTop">Optional: The character for the top-left corner.</param>
    /// <param name="rightTop">Optional: The character for the top-right corner.</param>
    /// <param name="leftBottom">Optional: The character for the bottom-left corner.</param>
    /// <param name="rightBottom">Optional: The character for the bottom-right corner.</param>
    /// <param name="horizontal">Optional: The character for the horizontal borders.</param>
    /// <param name="vertical">Optional: The character for the vertical borders.</param>
    public Frame(int windowWidth, int windowHeight, int? frameWidth = null, int? frameHeight = null, char leftTop = '╔', char rightTop = '╗', char leftBottom = '╚', char rightBottom = '╝', char horizontal = '═', char vertical = '║')
    {
        _windowWidth = windowWidth;
        _windowHeight = windowHeight;
        _leftTop = leftTop;
        _rightTop = rightTop;
        _leftBottom = leftBottom;
        _rightBottom = rightBottom;
        _horizontal = horizontal;
        _vertical = vertical;
        if (frameWidth != null)
            _frameWidth = frameWidth.Value;
        else
            _frameWidth = windowWidth;
        if (frameHeight != null)
            _frameHeight = frameHeight.Value;
        else
            _frameHeight = windowHeight;
    }

    /// <summary>
    /// Frame with custom text and default border characters.
    /// Default the frame will be same size as window if not specified.
    /// </summary>
    /// <param name="windowWidth">The windowWidth of the frame.</param>
    /// <param name="windowHeight">The windowHeight of the frame.</param>
    /// <param name="frameText">The text inside the frame.</param>
    /// <param name="frameWidth">Optional: The width of the frame.</param>
    /// <param name="frameHeight">Optional: The height of the frame.</param>
    /// <param name="leftTop">Optional: The character for the top-left corner.</param>
    /// <param name="rightTop">Optional: The character for the top-right corner.</param>
    /// <param name="leftBottom">Optional: The character for the bottom-left corner.</param>
    /// <param name="rightBottom">Optional: The character for the bottom-right corner.</param>
    /// <param name="horizontal">Optional: The character for the horizontal borders.</param>
    /// <param name="vertical">Optional: The character for the vertical borders.</param>
    public Frame(int windowWidth, int windowHeight, string[] frameText, int? frameWidth = null, int? frameHeight = null, char leftTop = '╔', char rightTop = '╗', char leftBottom = '╚', char rightBottom = '╝', char horizontal = '═', char vertical = '║')
    {
        _windowWidth = windowWidth;
        _windowHeight = windowHeight;
        _leftTop = leftTop;
        _rightTop = rightTop;
        _leftBottom = leftBottom;
        _rightBottom = rightBottom;
        _horizontal = horizontal;
        _vertical = vertical;
        if (frameWidth != null)
            _frameWidth = frameWidth.Value;
        else
            _frameWidth = GetMaxLengthOfString(frameText.ToList()) + 1;
        if (frameHeight != null)
            _frameHeight = frameHeight.Value;
        else
            _frameHeight = frameText.Length + 2;
        _frameText = new List<string>(frameText);
    }

    /// <summary>
    /// Sets the background color of the frame.
    /// </summary>
    /// <param name="color">The background color.</param>
    public void SetColorBg(ConsoleColor color)
    {
        FrameColorBg = color;
    }

    /// <summary>
    /// Sets the foreground color of the frame.
    /// </summary>
    /// <param name="color">The foreground color.</param>
    public void SetColorFg(ConsoleColor color)
    {
        FrameColorFg = color;
    }

    public void SetFrameText(string title)
    {
        _frameText = new List<string>();
        _frameHeight++;
        _frameText.Add(title);
    }

    public void SetFrameText(List<string> title)
    {
        _frameText = new List<string>();
        foreach (string line in title)
        {
            _frameHeight++;
            _frameText.Add(line);
        }
    }

    /// <summary>
    /// Renders the frame on the console.
    /// </summary>
    /// <param name="center">If set to <c>true</c>, the frame will be centered on the screen.</param>
    public void Render(bool center = false)
    {
        string text = "";
        if (center)
        {
            _startX = (_windowWidth - _frameWidth) / 2;
            _startY = (_windowHeight - _frameHeight) / 2;
        }

        Console.BackgroundColor = FrameColorBg;
        Console.ForegroundColor = FrameColorFg;

        // Draw top border
        Console.SetCursorPosition(_startX, _startY);
        Console.Write(_leftTop);
        for (int i = 0; i < _frameWidth - 1; i++)
        {
            Console.Write(_horizontal);
        }
        Console.Write(_rightTop);

        // Draw left and right border
        for (int i = 1; i < _frameHeight - 1; i++)
        {
            Console.SetCursorPosition(_startX, _startY + i);
            Console.Write(_vertical);
            Console.BackgroundColor = ConsoleColor.Black;
            if (_frameText != null)
            {
                text = _frameText.ElementAtOrDefault(i - 1) ?? "";
                Console.Write(text);
            }
            // Clear the inside of the box
            for (int j = 1; j < _frameWidth; j++)
            {
                Console.Write(" ");
            }
            Console.BackgroundColor = FrameColorBg;
            Console.SetCursorPosition(_startX + _frameWidth, _startY + i);
            Console.Write(_vertical);
        }

        // Draw bottom border
        Console.SetCursorPosition(_startX, _startY + _frameHeight - 1);
        Console.Write(_leftBottom);
        for (int i = 0; i < _frameWidth - 1; i++)
        {
            Console.Write(_horizontal);
        }
        Console.Write(_rightBottom);
        Console.ResetColor();
    }
    ///<summary>
    ///Get the max length of a string in a list of strings.
    ///</summary>
    ///<param name="strings">List of strings to check.</param>
    ///<returns>The max length of a string in the list.</returns>
    private int GetMaxLengthOfString(List<string> strings)
    {
        if (strings == null || strings.Count == 0)
            return 0;

        int maxLength = 0;
        foreach (var str in strings)
        {
            if (str.Length > maxLength)
                maxLength = str.Length;
        }
        return maxLength;
    }
}
