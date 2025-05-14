static void Main()
{
    // Dynamically get the correct base path at runtime
    string baseDir = AppDomain.CurrentDomain.BaseDirectory;

    // Path to the ASCII art text file (relative to output directory)
    string asciiFilePath = Path.Combine(baseDir, "Resources", "asciiart.txt");

    // Read ASCII art from the file
    string asciiArt = ReadAsciiArt(asciiFilePath);

    if (!string.IsNullOrEmpty(asciiArt))
    {
        Console.WriteLine(asciiArt);
    }
    else
    {
        Console.WriteLine("Error: ASCII art file is empty or not found.");
    }

    // Path to the sound file (also fixed)
    string soundFilePath = Path.Combine(baseDir, "Resources", "CyberChatVoice.wav");
