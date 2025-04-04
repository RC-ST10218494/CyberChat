using System;
using System.IO;
using System.Runtime.InteropServices; // Needed for OS detection
using System.Media; // For SoundPlayer (Windows only)

class Program
{
    static void Main()
    {
        // Path to the ASCII art text file
        string asciiFilePath = "Resources\\asciiart.txt";

        // Read ASCII art from the file
        string asciiArt = ReadAsciiArt(asciiFilePath);

        // If the file exists and is not empty, print the ASCII art
        if (!string.IsNullOrEmpty(asciiArt))
        {
            Console.WriteLine(asciiArt);
        }
        else
        {
            Console.WriteLine("Error: ASCII art file is empty or not found.");
        }

        // Path to the sound file
        string soundFilePath = "Resources\\CyberChatVoice.wav";

        // Play greeting sound (only on Windows)
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

        Console.WriteLine("How can I assist you with cybersecurity today?");

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

            string response = GetCyberSecurityResponse(userInput);
            Console.WriteLine($"CyberChat: {response}");
        }
    }

    static string ReadAsciiArt(string path)
    {
        try
        {
            // Read the content of the ASCII art file
            return File.Exists(path) ? File.ReadAllText(path) : null;
        }
        catch (Exception ex)
        {
            // If there is an error reading the file, print the error message
            Console.WriteLine($"Error reading ASCII art file: {ex.Message}");
            return null;
        }
    }

    static string GetCyberSecurityResponse(string input)
    {
        if (input.Contains("password"))
            return "Use strong passwords with a mix of letters, numbers, and symbols.";

        if (input.Contains("phishing"))
            return "Beware of phishing emails. Don't click suspicious links.";

        if (input.Contains("antivirus"))
            return "Always keep your antivirus software updated.";

        if (input.Contains("update"))
            return "Regularly update your software to patch security vulnerabilities.";

        return "I'm not sure about that. Can you ask about passwords, phishing, or updates?";
    }
}
