using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Media;

class Program
{
    static void Main()
    {
        // Path to ASCII art file
        string asciiFilePath = "Resources\\ASCIIArt.txt";

        // Read and display ASCII art
        string asciiArt = ReadAsciiArt(asciiFilePath);
        if (!string.IsNullOrEmpty(asciiArt))
        {
            Console.WriteLine(asciiArt);
        }
        else
        {
            Console.WriteLine("Error: ASCII art file is empty or not found.");
        }

        // Play greeting sound (Windows only)
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

        // Prompt user for name
        Console.Write("Welcome to CyberChat! What's your name? ");
        string userName = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(userName))
        {
            userName = "User";
        }

        // Create chatbot instance and greet
        CyberChatBot chatBot = new CyberChatBot(userName);
        Console.WriteLine($"\nHello {userName}, how can I assist you with cybersecurity today?\n");

        // Main chat loop
        while (true)
        {
            Console.Write("You: ");
            string userInput = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(userInput))
            {
                Console.WriteLine("CyberChat: Please enter a valid message.");
                continue;
            }

            if (userInput.ToLower() == "exit")
            {
                Console.WriteLine("CyberChat: Goodbye! Stay safe online.");
                break;
            }

            string response = chatBot.GetResponse(userInput);
            Console.WriteLine($"CyberChat: {response}");
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
