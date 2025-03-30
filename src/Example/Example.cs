using TirsvadCLI.Frame;

namespace Example;

/// <summary>
/// Example of how to use the Frame class.
/// </summary>
internal class Example
{
    static void Main(string[] args)
    {
        // Create a new frame with a window size of 20x20 and a frame size of 10x10
        Console.Clear();
        Console.WriteLine("Example 1");
        Console.WriteLine("This example shows how to create a Frame.\n");
        Frame frame = new Frame(windowWidth: 40, windowHeight: 24, frameWidth: 10, frameHeight: 10);
        frame.SetColorBg(ConsoleColor.DarkBlue); // Set background color of the frame
        frame.Render(true);
        Console.WriteLine("\nPress any key to see next example.");
        Console.ReadKey();

        // Clear the console and create a new frame with a window size of 20x20 and a frame size of 16x10
        Console.Clear();
        Console.WriteLine("Example 2");
        Console.WriteLine("This example shows how to set the text inside the frame and change the colors of the frame.\n");
        string[] frameText = new string[] { "Hello,", "World!", "Have a nice day" }; // Set text inside the frame
        frame = new Frame(windowWidth: 40, windowHeight: 24, frameText);
        frame.SetColorBg(ConsoleColor.White); // Set background color of the frame
        frame.SetColorFg(ConsoleColor.Blue); // Set foreground color of the frame
        frame.Render(true);
        Console.WriteLine("\nPress any key to see next example.");
        Console.ReadKey();

        // This will create a frame with a custom border.
        // The border will be made of char '*' instead of the default border characters.
        // Do not center the frame.
        Console.Clear();
        Console.SetCursorPosition(0, 12);
        Console.WriteLine("Example 3");
        Console.WriteLine("This example shows how to set the frame using char '*'.\n");
        frame = new Frame(windowWidth: 40, windowHeight: 24, frameWidth: 10, frameHeight: 10, leftTop: '*', rightTop: '*', leftBottom: '*', rightBottom: '*', horizontal: '*', vertical: '*');
        frame.Render(false); // Do not center the frame
        Console.WriteLine("\nPress any key to exit.");
        Console.ReadKey();
    }
}
