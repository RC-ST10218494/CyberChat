using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Media;

class Program
{
    static void Main()
    {
        // Path to ASCII art
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

        // Sound greeting
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

        // Start chatbot interaction
        CyberChatBot chatBot = new CyberChatBot();

        Console.WriteLine("\nCyberChat: How can I assist you with cybersecurity today?");
        while (true)
        {
            Console.Write("You: ");
            string userInput = Console.ReadLine()?.ToLower();

            if (string.IsNullOrWhiteSpace(userInput))
            {
                Console.WriteLine("CyberChat: Please enter a valid input.");
                continue;
            }

            if (userInput == "exit")
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
