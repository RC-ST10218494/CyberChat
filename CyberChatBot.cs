using System;
using System.Collections.Generic;

public class CyberChatBot
{
    private Dictionary<string, List<string>> keywordResponses;
    private string userName = "friend";
    private string favoriteTopic = null;

    public CyberChatBot()
    {
        keywordResponses = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase)
        {
            { "password", new List<string>
                {
                    "Use strong passwords with letters, numbers, and symbols.",
                    "Avoid reusing passwords across sites.",
                    "Never share your password with anyone."
                }
            },
            { "phishing", new List<string>
                {
                    "Phishing emails may look real—never click suspicious links.",
                    "Check the sender's address carefully in emails.",
                    "If in doubt, contact the company directly through their website."
                }
            },
            { "privacy", new List<string>
                {
                    "Adjust privacy settings on your social media accounts.",
                    "Be cautious about sharing personal information online.",
                    "Use privacy-focused search engines or browsers."
                }
            },
            { "scam", new List<string>
                {
                    "Watch out for deals that sound too good to be true.",
                    "Scammers often ask for payment in gift cards or crypto.",
                    "Report scams to your country's cybercrime unit."
                }
            }
        };
    }

    public string GetResponse(string input)
    {
        string sentimentResponse = GetSentimentResponse(input);
        string keywordResponse = GetKeywordResponse(input);

        if (!string.IsNullOrEmpty(sentimentResponse))
            return sentimentResponse + " " + keywordResponse;

        return keywordResponse;
    }

    private string GetKeywordResponse(string input)
    {
        foreach (var keyword in keywordResponses.Keys)
        {
            if (input.Contains(keyword))
            {
                if (favoriteTopic == null && (keyword == "privacy" || keyword == "scam"))
                {
                    favoriteTopic = keyword;
                    return $"Great! I'll remember that you're interested in {keyword}. It's important for cybersecurity.";
                }

                var responses = keywordResponses[keyword];
                Random rand = new Random();
                return responses[rand.Next(responses.Count)];
            }
        }

        return "I'm not sure I understand. Can you ask about password, phishing, privacy, or scam?";
    }

    private string GetSentimentResponse(string input)
    {
        if (input.Contains("worried") || input.Contains("anxious"))
        {
            return "It's okay to feel worried. Cyber threats are serious, but you can protect yourself.";
        }
        else if (input.Contains("curious"))
        {
            return "Curiosity is great! Let me give you something interesting about cybersecurity.";
        }
        else if (input.Contains("frustrated") || input.Contains("angry"))
        {
            return "Cybersecurity can be frustrating at times. You're doing great by asking questions!";
        }

        return null;
    }
}
