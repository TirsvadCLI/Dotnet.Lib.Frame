namespace TirsvadCLI;
class Frame
{
    private int _windowWidth; // Width of the frame
    private int _windowHeight; // Height of the frame
    private int _width; // Width of the frame. Can be different from windowWidth when using center frame
    private int _height; // Height of the frame. Can be different from windowHeight when using center frame
    private int _startX = 0; // Start position of the frame on the x-axis
    private int _startY = 0; // Start position of the frame on the y-axis
    private char _leftTop = '╔'; // Character for the top-left corner
    private char _rightTop = '╗'; // Character for the top-right corner
    private char _leftBottom = '╚'; // Character for the bottom-left corner
    private char _rightBottom = '╝'; // Character for the bottom-right corner
    private char _horizontal = '═'; // Character for the horizontal borders
    private char _vertical = '║'; // Character for the vertical borders

    private List<string>? _frameText; // Title of the frame

    private ConsoleColor FrameColorBg = ConsoleColor.Black; // Background color of the frame
    private ConsoleColor FrameColorFg = ConsoleColor.White; // Foreground color of the frame

    /// <summary>
    /// Initializes a new instance of the <see cref="Frame"/> class with specified width and height.
    /// </summary>
    /// <param name="width">The width of the frame.</param>
    /// <param name="height">The height of the frame.</param>
    public Frame(int width, int height)
    {
        _width = _windowWidth = width;
        _height = _windowHeight = height;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Frame"/> class with specified dimensions and border characters.
    /// </summary>
    /// <param name="width">The width of the frame.</param>
    /// <param name="height">The height of the frame.</param>
    /// <param name="leftTop">The character for the top-left corner.</param>
    /// <param name="rightTop">The character for the top-right corner.</param>
    /// <param name="leftBottom">The character for the bottom-left corner.</param>
    /// <param name="rightBottom">The character for the bottom-right corner.</param>
    /// <param name="horizontal">The character for the horizontal borders.</param>
    /// <param name="vertical">The character for the vertical borders.</param>
    public Frame(int width, int height, char leftTop, char rightTop, char leftBottom, char rightBottom, char horizontal, char vertical)
    {
        _windowWidth = width;
        _windowHeight = height;
        _width = width;
        _height = height;
        _leftTop = leftTop;
        _rightTop = rightTop;
        _leftBottom = leftBottom;
        _rightBottom = rightBottom;
        _horizontal = horizontal;
        _vertical = vertical;
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
        _height++;
        _frameText.Add(title);
    }

    public void SetFrameText(List<string> title)
    {
        _frameText = new List<string>();
        foreach (string line in title)
        {
            _height++;
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
            // Do something special for box in the center of the screen
            throw new NotImplementedException();
        }

        Console.BackgroundColor = FrameColorBg;
        Console.ForegroundColor = FrameColorFg;

        // Draw top border
        Console.SetCursorPosition(_startX, _startY);
        Console.Write(_leftTop);
        for (int i = 0; i < _width - 1; i++)
        {
            Console.Write(_horizontal);
        }
        Console.Write(_rightTop);

        // Draw left and right border
        for (int i = 1; i < _height - 1; i++)
        {
            if (_frameText != null)
                text = _frameText.ElementAtOrDefault(i - 1) ?? "";
            Console.SetCursorPosition(_startX, _startY + i);
            Console.Write(_vertical);
            Console.Write(" " + text);
            // Clear the inside of the box
            Console.BackgroundColor = ConsoleColor.Black;
            for (int j = 1; j < _width; j++)
            {
                Console.Write(" ");
            }
            Console.BackgroundColor = FrameColorBg;
            Console.SetCursorPosition(_startX + _width, _startY + i);
            Console.Write(_vertical);
        }

        // Draw bottom border
        Console.SetCursorPosition(_startX, _startY + _height - 1);
        Console.Write(_leftBottom);
        for (int i = 0; i < _width - 1; i++)
        {
            Console.Write(_horizontal);
        }
        Console.Write(_rightBottom);

        Console.ResetColor();
    }
}
