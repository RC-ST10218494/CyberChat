using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Media;

class Program
{
    // Memory storage
    static string userName = "";
    static string favoriteTopic = "";

    // Randomizer
    static Random rand = new Random();

    static void Main()
    {
        ShowAsciiArt();
        PlayGreetingSound();

        Console.WriteLine("CyberChat: Hi there! What's your name?");
        Console.Write("You: ");
        userName = Console.ReadLine();
        Console.WriteLine($"CyberChat: Nice to meet you, {userName}! How can I assist you with cybersecurity today?");

        while (true)
        {
            Console.Write("\nYou: ");
            string userInput = Console.ReadLine()?.ToLower();

            if (string.IsNullOrWhiteSpace(userInput))
            {
                Console.WriteLine("CyberChat: Please enter something meaningful.");
                continue;
            }

            if (userInput == "exit")
            {
                Console.WriteLine($"CyberChat: Goodbye {userName}! Stay safe online.");
                break;
            }

            Console.WriteLine($"CyberChat: {GetResponse(userInput)}");
        }
    }

    static void ShowAsciiArt()
    {
        string path = "Resources\\ASCIIArt.txt";
        if (File.Exists(path))
        {
            Console.WriteLine(File.ReadAllText(path));
        }
        else
        {
            Console.WriteLine("Error: ASCII art not found.");
        }
    }

    static void PlayGreetingSound()
    {
        string path = "Resources\\greeting.wav";
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows) && File.Exists(path))
        {
            try
            {
                new SoundPlayer(path).Play();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error playing sound: {ex.Message}");
            }
        }
    }

    static string GetResponse(string input)
    {
        if (DetectSentiment(input, out string sentimentResponse))
            return sentimentResponse;

        if (DetectKeyword(input, out string keywordResponse))
            return keywordResponse;

        if (input.Contains("name"))
            return $"Your name is {userName}, of course!";

        if (input.Contains("favorite") || input.Contains("interested"))
        {
            if (input.Contains("privacy"))
            {
                favoriteTopic = "privacy";
                return "Great! I'll remember that you're interested in privacy. It's a crucial part of staying safe online.";
            }
            else if (!string.IsNullOrEmpty(favoriteTopic))
            {
                return $"As someone interested in {favoriteTopic}, remember to review your security settings regularly.";
            }
        }

        return "I'm not sure I understand. Could you rephrase or ask about passwords, scams, or privacy?";
    }

    static bool DetectKeyword(string input, out string response)
    {
        var phishingTips = new List<string>
        {
            "Be cautious of emails asking for personal info.",
            "Avoid clicking suspicious links in messages.",
            "Always verify the sender's email address."
        };

        if (input.Contains("password"))
        {
            response = "Use strong, unique passwords with letters, numbers, and symbols.";
            return true;
        }
        else if (input.Contains("scam") || input.Contains("phishing"))
        {
            response = phishingTips[rand.Next(phishingTips.Count)];
            return true;
        }
        else if (input.Contains("privacy"))
        {
            response = "Check your social media privacy settings and limit what you share publicly.";
            return true;
        }

        response = null;
        return false;
    }

    static bool DetectSentiment(string input, out string response)
    {
        if (input.Contains("worried") || input.Contains("scared"))
        {
            response = "It's okay to feel worried. Scammers are tricky, but with the right knowledge, you're safe.";
            return true;
        }
        if (input.Contains("frustrated"))
        {
            response = "Frustration is normal. Cybersecurity can be complex, but I'm here to help you through it.";
            return true;
        }
        if (input.Contains("curious"))
        {
            response = "Curiosity is great! Let me help you explore cybersecurity topics.";
            return true;
        }

        response = null;
        return false;
    }
}
