using TirsvadCLI.Frame;

namespace Example;

/// <summary>
/// Examples of how to use the Frame class.
/// </summary>
internal class Program
{
    /// <summary>
    /// Example 1:
    /// Create a new frame with default values and set the text inside the frame.
    /// Set start position of the frame below explanation and render it.
    /// </summary>
    static void Example1()
    {
        Console.Clear();
        Console.WriteLine("Example 1\n");
        Console.WriteLine("This example shows how to set the text inside the frame.");
        Console.WriteLine("It will center the text inside the frame.\n");

        string[] frameText = ["Hello,", "World!", "Have a nice day"]; // Set text inside the frame
        Frame frame = new Frame(); // Create a new frame with default values
        frame.SetStartPosition(Console.GetCursorPosition()); // Optional: Set the start position of the frame
        frame.FrameText(frameText, true); // Set text inside the frame and center it if set to true
        frame.Render(); // Render the frame

        Console.WriteLine("\nPress any key to see next example.");
        Console.ReadKey();
    }

    /// <summary>
    /// Example 2:
    /// Create a new frame with custom size and set the text inside the frame.
    /// Set background and foreground color of the frame.
    /// Set start position of the frame below explanation and render it.
    /// </summary>
    static void Example2()
    {
        Console.Clear();
        Console.WriteLine("Example 2\n");
        Console.WriteLine("This example shows how to set the text inside the frame");
        Console.WriteLine("and change the colors of the frame.");
        Console.WriteLine("It will center the frame according to windows size we defined.\n");

        // Creating the frame
        string[] frameText = new string[] { "Hello,", "World!", "Have a nice day" }; // Set text inside the frame
        Frame frame = new Frame(windowWidth: 80, windowHeight: 40, frameText);
        frame.SetColorBg(ConsoleColor.White); // Set background color of the frame
        frame.SetColorFg(ConsoleColor.Blue); // Set foreground color of the frame
        frame.Render(true); // Center the frame and render it

        Console.WriteLine("\nPress any key to see next example.");
        Console.ReadKey();
    }

    /// <summary>
    /// Example 3:
    /// Create a new frame with custom size and set the text inside the frame.
    /// Set custom border characters for the frame.
    /// </summary>
    static void Example3()
    {
        // This will create a frame with a custom border.
        // The border will be made of char '*' instead of the default border characters.
        // Do not center the frame.
        Console.Clear();
        Console.WriteLine("Program 3\n");
        Console.WriteLine("This example shows how to set the frame using char '*'.\n");

        Frame frame = new(windowWidth: 40, windowHeight: 24, frameWidth: 10, frameHeight: 10, leftTop: '*', rightTop: '*', leftBottom: '*', rightBottom: '*', horizontal: '*', vertical: '*'); ;
        frame.SetStartPosition(Console.GetCursorPosition()); // Optional: Set the start position of the frame
        frame.Render(false); // Do not center the frame

        Console.WriteLine("\nPress any key to see next example.");
        Console.ReadKey();
    }


    /// <summary>
    /// Example 4:
    /// Center a text.
    /// </summary>
    static void Example4()
    {
        Frame frame = new();
        Console.Clear();
        Console.WriteLine("Example 4\n");
        Console.WriteLine(frame.CenterText("A centered text", 40));
        Console.WriteLine("\nPress any key to exit.");
        Console.ReadKey();
    }

    static void Main(string[] args)
    {
        Example1();
        Example2();
        Example3();
        Example4();
    }
}
