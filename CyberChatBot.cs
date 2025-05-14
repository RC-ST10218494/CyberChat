using System;
using System.Collections.Generic;

public class CyberChatBot
{
    private Dictionary<string, string> _cyberSecurityKeywords;

    public CyberChatBot()
    {
        // Initialize the dictionary with cybersecurity-related keywords and responses
        _cyberSecurityKeywords = new Dictionary<string, string>
        {
            { "password", "Use strong passwords with a mix of letters, numbers, and symbols." },
            { "phishing", "Beware of phishing emails. Don't click suspicious links." },
            { "antivirus", "Always keep your antivirus software updated." },
            { "update", "Regularly update your software to patch security vulnerabilities." },
            { "scam", "Be cautious of unsolicited messages asking for personal information." },
            { "privacy", "Make sure to review privacy settings on your accounts and devices regularly." }
        };
    }

    // Method to get a response based on user input
    public string GetResponse(string input)
    {
        foreach (var keyword in _cyberSecurityKeywords)
        {
            if (input.Contains(keyword.Key))
            {
                return keyword.Value;
            }
        }
        return "I'm not sure about that. Can you ask about passwords, phishing, or updates?";
    }
}
