using System;
using System.Media;
using System.IO;
using System.Threading;

class CyberChat
{
    static void Main()
    {
        // Display ASCII Art
        DisplayAsciiArt();

        // Play the Voice Greeting
        PlayVoiceGreeting();

        // Greet the User
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\nWelcome to CyberChat! Your Cybersecurity Awareness Assistant.");
        Console.ResetColor();

        // Ask for User's Name
        Console.Write("\nPlease enter your name: ");
        string userName = Console.ReadLine()?.Trim();

        while (string.IsNullOrEmpty(userName))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Name cannot be empty! Please enter your name.");
            Console.ResetColor();
            Console.Write("\nEnter your name: ");
            userName = Console.ReadLine()?.Trim();
        }

        Console.WriteLine($"\nHello, {userName}! I'm here to help you with cybersecurity awareness.\n");

        // Chat Interaction
        ChatWithUser();
    }

    static void DisplayAsciiArt()
    {
        string path = "ASCIIArt.txt";
        if (File.Exists(path))
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(File.ReadAllText(path));
            Console.ResetColor();
        }
        else
        {
            Console.WriteLine("ASCII Art file missing!");
        }
    }

    static void PlayVoiceGreeting()
    {
        string audioFile = "greeting.wav";
        if (File.Exists(audioFile))
        {
            SoundPlayer player = new SoundPlayer(audioFile);
            player.PlaySync();
        }
        else
        {
            Console.WriteLine("Voice greeting file missing!");
        }
    }

    static void ChatWithUser()
    {
        while (true)
        {
            Console.Write("\nAsk me about cybersecurity (or type 'exit' to quit): ");
            string userInput = Console.ReadLine()?.ToLower().Trim();

            if (userInput == "exit")
            {
                Console.WriteLine("Goodbye! Stay safe online.");
                break;
            }

            switch (userInput)
            {
                case "how are you?":
                    Console.WriteLine("I'm just a bot, but I'm here to help!");
                    break;
                case "what's your purpose?":
                    Console.WriteLine("I educate people about online safety and cybersecurity.");
                    break;
                case "password safety":
                    Console.WriteLine("Use long and unique passwords. A password manager can help!");
                    break;
                case "phishing":
                    Console.WriteLine("Phishing is when scammers trick you into giving personal information. Be cautious of suspicious emails!");
                    break;
                case "safe browsing":
                    Console.WriteLine("Always check URLs before clicking. Avoid unknown websites!");
                    break;
                default:
                    Console.WriteLine("I didn't quite understand that. Could you rephrase?");
                    break;
            }
        }
    }
}
