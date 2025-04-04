using System;
using System.Runtime.InteropServices; // Needed for OS detection
using System.Media; // For SoundPlayer (Windows only)
using System.IO; // For File.Exists check

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to CyberChat!");

        // Play greeting sound (only on Windows)
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            // Define the path to the sound file
            string soundFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "greeting.wav");

            // Check if the file exists
            if (File.Exists(soundFilePath))
            {
                try
                {
                    // Create the SoundPlayer object
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
                Console.WriteLine("Error playing sound: File not found at " + soundFilePath);
            }
        }
        else
        {
            Console.WriteLine("Sound is only supported on Windows.");
        }

        Console.WriteLine("How can I assist you with cybersecurity today?");

        // Main loop for the chatbot
        while (true)
        {
            Console.Write("You: ");
            string userInput = Console.ReadLine()?.ToLower();

            if (string.IsNullOrWhiteSpace(userInput))
            {
                Console.WriteLine("CyberChat: Please enter a valid input.");
                continue;
            }

            // Exit condition
            if (userInput == "exit")
            {
                Console.WriteLine("CyberChat: Goodbye! Stay safe online.");
                break;
            }

            // Get the response based on user input
            string response = GetCyberSecurityResponse(userInput);
            Console.WriteLine($"CyberChat: {response}");
        }
    }

    // Function to provide responses based on user input
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
