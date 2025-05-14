using System;
using System.Collections.Generic;

public class CyberChatBot
{
    private Dictionary<string, List<string>> responses;
    private string userName;
    private string favoriteTopic;
    private string lastTopic;

    public CyberChatBot()
    {
        InitializeResponses();
        userName = null;
        favoriteTopic = null;
        lastTopic = null;
    }

    private void InitializeResponses()
    {
        responses = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase)
        {
            { "password", new List<string>
                {
                    "Use strong passwords with a mix of letters, numbers, and symbols.",
                    "Avoid using the same password across multiple sites.",
                    "Consider using a password manager to store your credentials."
                }
            },
            { "phishing", new List<string>
                {
                    "Never click on suspicious links in emails.",
                    "Double-check the sender's email address before responding.",
                    "Phishing scams often create a sense of urgency — stay calm and verify first."
                }
            },
            { "privacy", new List<string>
                {
                    "Always check the permissions apps request on your devices.",
                    "Limit the personal information you share online.",
                    "Use privacy settings on social media platforms."
                }
            },
            { "scam", new List<string>
                {
                    "Be cautious of 'too good to be true' deals.",
                    "Don’t share personal or financial information with unknown contacts.",
                    "Report scams to your local authority or platform support."
                }
            }
        };
    }

    public string GetResponse(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return "CyberChat: Please enter something for me to respond to.";

        input = input.ToLower();

        // Sentiment handling
        if (input.Contains("worried"))
            return "It's completely understandable to feel worried. Cyber threats can be scary, but I'm here to help.";

        if (input.Contains("curious"))
            return "Curiosity is great! Cybersecurity knowledge helps you stay protected. Ask away!";

        if (input.Contains("frustrated"))
            return "Don't worry — cybersecurity can be tricky, but together we'll make it simple.";

        // Name memory (e.g., "My name is Sam")
        if (input.StartsWith("my name is"))
        {
            userName = input.Substring(11).Trim();
            return $"Nice to meet you, {userName}! I'm here to help with cybersecurity.";
        }

        // Favorite topic memory (e.g., "I'm interested in privacy")
        if (input.Contains("i'm interested in"))
        {
            favoriteTopic = input.Substring(input.IndexOf("i'm interested in") + 17).Trim();
            return $"Great! I'll remember that you're interested in {favoriteTopic}. It's an important area of cybersecurity.";
        }

        // Follow-up detection
        if (input.Contains("tell me more") || input.Contains("more info"))
        {
            if (!string.IsNullOrEmpty(lastTopic) && responses.ContainsKey(lastTopic))
            {
                Random rand = new Random();
                var followUps = responses[lastTopic];
                return followUps[rand.Next(followUps.Count)];
            }
            else
            {
                return "Could you clarify what you'd like more information about?";
            }
        }

        // Keyword match
        foreach (var keyword in responses.Keys)
        {
            if (input.Contains(keyword))
            {
                lastTopic = keyword;
                Random rand = new Random();
                var replyList = responses[keyword];
                return replyList[rand.Next(replyList.Count)];
            }
        }

        return "I'm not sure I understand. Can you try rephrasing or ask about topics like passwords, scams, or privacy?";
    }
}
