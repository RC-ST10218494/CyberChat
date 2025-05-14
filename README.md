# 🛡️ CyberChat – Cybersecurity Awareness Bot (Part 2)

> Student ID: **ST10218494**  
> Project Phase: **Part 2 – Enhanced Chatbot with Keywords, Sentiment, Delegates**

---

## 📘 Overview

CyberChat is a simple, interactive **C# console application** that helps users learn about **cybersecurity** topics in a friendly way.

It simulates a conversation where the bot can recognize important **keywords** like "passwords" and "phishing", detect your mood, and give helpful tips on how to stay safe online.

---

## ✅ Features Summary

| Feature                                              | Status |
|------------------------------------------------------|--------|
| 🎤 Voice greeting (`greeting.wav`)                   | ✅ Done |
| 🎨 ASCII Art display from file                       | ✅ Done |
| 👤 User personalization (name input)                 | ✅ Done |
| 💬 Basic chatbot conversation                        | ✅ Done |
| 🧠 Keyword detection (e.g., password, phishing)      | ✅ Done |
| 🙂 Sentiment detection (e.g., "I'm sad", "angry")    | ✅ Done |
| 🧩 Delegates for chatbot logic                       | ✅ Done |
| 🚫 Input validation (empty or unknown questions)     | ✅ Done |
| 🎨 Colored console text                              | ✅ Done |
| ⚙️ GitHub CI workflow (build/test)                   | ✅ Done |
| 📄 README documentation                              | ✅ Done |

---

## 💡 How to Use CyberChat

### 🔧 Run the Application

1. Open your terminal or command prompt.
2. Navigate to the `CyberChat` folder.
3. Run this command:

```bash
dotnet run



💬 What You Can Ask
Here are some example inputs to try with the chatbot:
| Example Input                | What Happens                                 |
| ---------------------------- | -------------------------------------------- |
| `Tell me about passwords`    | Bot gives password safety tips               |
| `What is phishing?`          | Bot explains phishing scams                  |
| `How do I stay safe online?` | General cybersecurity advice                 |
| `I'm feeling sad`            | Bot gives a supportive sentiment-based reply |
| `I hate hackers`             | Bot reacts to negative sentiment             |
| `exit` or `quit`             | Ends the chatbot conversation                |


📁 Project Files
| File                       | Purpose                              |
| -------------------------- | ------------------------------------ |
| `Program.cs`               | Main chatbot loop & greeting logic   |
| `CyberChatBot.cs`          | Bot brain: response logic, keywords  |
| `Resources/ASCIIArt.txt`   | ASCII banner displayed at launch     |
| `Resources/greeting.wav`   | Voice welcome message (Windows only) |
| `.github/workflows/ci.yml` | GitHub Actions workflow for CI       |
| `CyberChat.csproj`         | .NET project file                    |
| `README.md`                | This project guide                   |

💻 Requirements
.NET 8.0 SDK installed

Works best on Windows (for sound playback)

🚀 What’s New in Part 2?
Smart keywords: CyberChat recognizes words like phishing, password, update, malware, etc.

Emotional awareness: The bot reacts to how you’re feeling!

Cleaner code: Uses delegates to separate responsibilities.

Improved experience: More natural replies and a smarter chat loop.

🧪 Continuous Integration
CyberChat uses GitHub Actions to automatically:

Build the program

Check for syntax errors

Validate changes

No setup needed—just push to GitHub and it builds!

🙋 About
Student: ST10218494

Module: PROG6221

Goal: Educate South African users about online safety

🏁 What's Next? (Part 3 Preview)
🧠 Add a mini-game or interactive quiz

📹 Create a video walkthrough (8–10 minutes)

💬 More advanced conversation logic


