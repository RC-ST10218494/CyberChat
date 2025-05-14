using System;
using System.Collections.Generic;

public delegate string ChatResponseHandler(string userInput);

public class CyberChatBot
{
    private readonly Dictionary<string, List<string>> keywordResponses;
    private readonly Dictionary<string, string> memory;

    public CyberChatBot()
    {
        memory = new Dictionary<string, string>();

        keywordResponses = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase)
        {
            ["password"] = new List<string>
            {
                "Use a strong, unique password for every account.",
                "Never reuse old passwords.",
                "Use a password manager to store passwords securely."
            },
            ["phishing"] = new List<string>
            {
                "Be cautious of unexpected emails asking for personal info.",
                "Avoid clicking on suspicious links.",
                "Verify email sender addresses before responding."
            },
            ["privacy"] = new List<string>
            {
                "Review privacy settings on all your social accounts.",
                "Avoid oversharing personal information online.",
                "Use secure and encrypted messaging apps."
            },
            ["scam"] = new List<string>
            {
                "If it sounds too good to be true, it probably is.",
                "Scammers often impersonate official institutions.",
                "Always verify through trusted sources before sharing details."
            }
        };
    }

    public string GetResponse(string input)
    {
        if (input.Contains("name is"))
        {
            string name = input.Substring(input.IndexOf("name is") + 7).Trim();
            memory["name"] = name;
            return $"Nice to meet you, {name}!";
        }

        if (input.Contains("interested in"))
        {
            string topic = input.Substring(input.IndexOf("interested in") + 13).Trim();
            memory["interest"] = topic;
            return $"Great! I'll remember you're interested in {topic}.";
        }

        if (input.Contains("worried") || input.Contains("frustrated"))
            return "It's okay to feel that way. Let's go over how you can protect yourself.";

        if (input.Contains("curious"))
            return "Curiosity is the first step to being informed. Let's learn together!";

        foreach (var keyword in keywordResponses.Keys)
        {
            if (input.Contains(keyword))
            {
                var responses = keywordResponses[keyword];
                return responses[new Random().Next(responses.Count)];
            }
        }

        if (memory.ContainsKey("interest"))
        {
            return $"As someone interested in {memory["interest"]}, you should explore ways to secure your data.";
        }

        return "I'm not sure I understand. Can you try rephrasing your question?";
    }
}