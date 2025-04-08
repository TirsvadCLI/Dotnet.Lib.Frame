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

    private ICollection<string>? _frameText; // Title of the frame

    private ConsoleColor _frameColorBg = ConsoleColor.Black; // Background color of the frame
    private ConsoleColor _frameColorFg = ConsoleColor.White; // Foreground color of the frame
    private ConsoleColor _textColorBg = ConsoleColor.Black; // Background color of the text
    private ConsoleColor _textColorFg = ConsoleColor.White; // Foreground color of the text

    /// <summary>
    /// Default constructor.
    /// </summary>
    public Frame()
    {
        // Default constructor
        // Initialize default values
        _windowWidth = 0;
        _windowHeight = 0;
        _frameWidth = 0;
        _frameHeight = 0;
        _startX = 0;
        _startY = 0;
        _leftTop = '╔';
        _rightTop = '╗';
        _leftBottom = '╚';
        _rightBottom = '╝';
        _horizontal = '═';
        _vertical = '║';
        _frameText = null;
        _frameColorBg = ConsoleColor.Black;
        _frameColorFg = ConsoleColor.White;
        _textColorBg = ConsoleColor.Black;
        _textColorFg = ConsoleColor.White;
    }

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
            _frameHeight = frameText.Count() + 2;
        _frameText = frameText;
    }

    /// <summary>
    /// Sets the start position of the frame.
    /// </summary>
    /// <param name="startPosition"></param>
    public void SetStartPosition((int Left, int Top) startPosition)
    {
        _startX = startPosition.Left;
        _startY = startPosition.Top;
    }

    /// <summary>
    /// Sets the background color of the frame.
    /// </summary>
    /// <param name="color">The background color.</param>
    public void SetColorBg(ConsoleColor color)
    {
        _frameColorBg = _textColorBg = color;
    }

    /// <summary>
    /// Sets the foreground color of the frame.
    /// </summary>
    /// <param name="color">The foreground color.</param>
    public void SetColorFg(ConsoleColor color)
    {
        _frameColorFg = _textColorFg = color;
    }

    /// <summary>
    /// Sets the background color of the text.
    /// </summary>
    /// <param name="color">The background color.</param>
    public void SetTextColorBg(ConsoleColor color)
    {
        _textColorBg = color;
    }

    /// <summary>
    /// Sets the foreground color of the text.
    /// </summary>
    /// <param name="color">The foreground color.</param>
    public void SetTextColorFg(ConsoleColor color)
    {
        _textColorFg = color;
    }

    /// <summary>
    /// Sets the background color of the frame.
    /// </summary>
    /// <param name="color">The background color.</param>
    public void SetFrameColorBg(ConsoleColor color)
    {
        _frameColorBg = color;
    }

    /// <summary>
    /// Sets the foreground color of the frame.
    /// </summary>
    /// <param name="color">The foreground color.</param>
    public void SetFrameColorFg(ConsoleColor color)
    {
        _frameColorFg = color;
    }

    /// <summary>
    /// Sets the text inside the frame.
    /// </summary>
    /// <param name="title">The text inside the frame.</param>
    public void SetFrameText(string title)
    {
        _frameText = new List<string>();
        _frameHeight++;
        _frameText.Add(title);
    }

    /// <summary>
    /// Sets the text inside the frame.
    /// </summary>
    /// <param name="title">The text inside the frame.</param>
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

        Console.BackgroundColor = _frameColorBg;
        Console.ForegroundColor = _frameColorFg;

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
                Console.BackgroundColor = _textColorBg;
                Console.ForegroundColor = _textColorFg;
                text = _frameText.ElementAtOrDefault(i - 1) ?? "";
                Console.Write(text);
            }
            // Clear the inside of the box
            for (int j = 1; j < _frameWidth - text.Length; j++)
            {
                Console.BackgroundColor = _textColorBg;
                Console.ForegroundColor = _textColorFg;
                Console.Write(" ");
            }
            Console.BackgroundColor = _frameColorBg;
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

    /// <summary>
    /// Frames the text.
    /// Optionally center the text.
    /// </summary>
    /// <param name="texts">The text to frame.</param>
    /// <param name="centerText">If set to <c>true</c>, the text will be centered.</param>
    public void FrameText(ICollection<string> texts, bool centerText = false)
    {
        int linesOfText = 0;
        int maxLength = 0;
        string prefix = " ";
        ICollection<string> frameText = new List<string>();
        linesOfText = texts.Count();
        maxLength = GetMaxLengthOfString(texts.ToList());
        if (linesOfText == 0)
            return;
        if (linesOfText > _frameHeight)
            _frameHeight = linesOfText + 2;
        if (linesOfText > _windowHeight)
            _windowHeight = linesOfText + 2;
        if (maxLength > _frameWidth)
            _frameWidth = maxLength + 3;
        if (maxLength > _windowWidth)
            _windowWidth = maxLength + 3;
        for (int i = 0; i < linesOfText; i++)
        {
            if (texts.ElementAtOrDefault(i) != null)
                if (centerText)
                    frameText.Add(CenterText(texts.ElementAt(i), maxLength + 2));
                else
                    frameText.Add(texts.ElementAt(i).Insert(0, prefix));
        }
        _frameText = frameText;
    }

    /// <summary>
    /// Centers the text in the frame.
    /// </summary>
    /// <param name="text">The text to center.</param>
    /// <param name="width">The width of the frame.</param>
    /// <returns>The centered text.</returns>
    public string CenterText(string text, int width)
    {
        if (width <= text.Length)
        {
            return text; // Or throw an exception, or truncate the string
        }
        int padding = width - text.Length;
        int leftPadding = padding / 2;
        int rightPadding = padding - leftPadding;
        return new string(' ', leftPadding) + text + new string(' ', rightPadding);
    }
}
