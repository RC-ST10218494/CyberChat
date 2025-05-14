using System;
using System.IO;
using System.Runtime.InteropServices; // Needed for OS detection
using System.Media; // For SoundPlayer (Windows only)

class Program
{
    static void Main()
    {
        string asciiFilePath = "Resources\\ASCIIArt.txt";
        string asciiArt = ReadAsciiArt(asciiFilePath);

        if (!string.IsNullOrEmpty(asciiArt))
        {
            Console.WriteLine(asciiArt);
        }
        else
        {
            Console.WriteLine("Error: ASCII art file is empty or not found.");
        }

        string soundFilePath = "Resources\\CyberChatVoice.wav";

        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            if (File.Exists(soundFilePath))
            {
                try
                {
                    SoundPlayer player = new SoundPlayer(soundFilePath);
                    player.Play();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error playing sound: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine($"Error: Sound file '{soundFilePath}' not found.");
            }
        }
        else
        {
            Console.WriteLine("Sound is only supported on Windows.");
        }

        Console.WriteLine("\nCyberChat: Hello! How can I assist you with cybersecurity today?");
        Console.WriteLine("Type 'exit' to end the chat.\n");

        CyberChatBot bot = new CyberChatBot();

        while (true)
        {
            Console.Write("You: ");
            string userInput;

            try
            {
                userInput = Console.ReadLine();
            }
            catch (IOException)
            {
                Console.WriteLine("\nCyberChat: Input error encountered. Exiting chat.");
                break;
            }

            if (userInput == null)
            {
                Console.WriteLine("\nCyberChat: Input was null. Ending session for your safety.");
                break;
            }

            userInput = userInput.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(userInput))
            {
                Console.WriteLine("CyberChat: Please enter a valid question or type 'exit' to leave.");
                continue;
            }

            if (userInput == "exit")
            {
                Console.WriteLine("CyberChat: Goodbye! Stay safe online.");
                break;
            }

            try
            {
                string response = bot.GetResponse(userInput);
                Console.WriteLine($"CyberChat: {response}\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"CyberChat: Oops! Something went wrong: {ex.Message}");
            }
        }
    }

    static string ReadAsciiArt(string path)
    {
        try
        {
            return File.Exists(path) ? File.ReadAllText(path) : null;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading ASCII art file: {ex.Message}");
            return null;
        }
    }
}
