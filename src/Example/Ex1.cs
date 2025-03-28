using TirsvadCLI;

namespace Example;

/// <summary>
/// Example of how to use the Frame class.
/// </summary>
internal class Ex1
{
    static void Main(string[] args)
    {
        // Create a new frame with a window size of 20x20 and a frame size of 10x10
        Frame frame = new Frame(windowWidth: 20, windowHeight: 20, frameWidth: 10, frameHeight: 10);
        frame.SetColorBg(ConsoleColor.DarkBlue); // Set background color of the frame
        frame.Render(true);
        Console.WriteLine("\nPress any key to see next example.");
        Console.ReadKey();

        // Clear the console and create a new frame with a window size of 20x20 and a frame size of 16x10
        Console.Clear();
        frame = new Frame(windowWidth: 20, windowHeight: 20, frameWidth: 16, frameHeight: 10);
        frame.SetFrameText("Hello, World!"); // Set text inside the frame
        frame.SetColorBg(ConsoleColor.White); // Set background color of the frame
        frame.SetColorFg(ConsoleColor.Blue); // Set foreground color of the frame
        frame.Render(true);
        Console.WriteLine("\nPress any key to see next example.");
        Console.ReadKey();

        // Clear the console and create a new frame with a window size of 20x20 and a frame size of 10x10
        Console.Clear();
        frame = new Frame(windowWidth: 20, windowHeight: 20, frameWidth: 10, frameHeight: 10, leftTop: '*', rightTop: '*', leftBottom: '*', rightBottom: '*', horizontal: '*', vertical: '*');
        frame.Render(true);
        Console.WriteLine("\nPress any key to exit.");
        Console.ReadKey();
    }
}
