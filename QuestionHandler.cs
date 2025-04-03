using System.Collections.Generic;
using System.Collections;
using System;

namespace CyberSecurityBot
{
    // Subclass for handling user questions and responses
    public class QuestionHandler
    {
        private List<string> replies = new List<string>();
        private List<string> ignore = new List<string>();

        // Constructor initializes ignored words and reply database
        public QuestionHandler()
        {
            StoreIgnore();
            StoreReplies();
        }

        // Handles user queries and provides relevant responses
        public void HandleQuestions(string userName)
        {
            while (true)
            {
                Console.WriteLine("Chat AI-> Enter your question (or 'exit' to go back to the main menu):");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(userName + " -> ");
                string question = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Cyan;

                // Allows user to exit the questioning loop
                if (question?.ToLower() == "exit")
                {
                    Console.WriteLine("Goodbye! " + userName);
                    return;
                }

                string[] words = question.Split(' ');
                ArrayList filteredWords = new ArrayList();

                // Filters out common words that do not add meaning to the question
                foreach (string word in words)
                {
                    if (!ignore.Contains(word.ToLower()))
                    {
                        filteredWords.Add(word);
                    }
                }

                bool found = false;
                string message = string.Empty;

                // Searches for relevant answers based on keywords
                foreach (string word in filteredWords)
                {
                    foreach (string reply in replies)
                    {
                        if (reply.IndexOf(word, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            message += reply + "\n";
                            found = true;
                        }
                    }
                }

                // Displays an appropriate response or asks the user to rephrase
                if (found)
                {
                    Console.WriteLine("Chat AI -> " + message);
                }
                else
                {
                    Console.WriteLine("Chat AI-> I couldn't find an answer. Try rephrasing your question.");
                }
            }
        }

        // Stores predefined responses to common cybersecurity questions
        private void StoreReplies()
        {
            replies.Add("password -> Always use strong passwords with a mix of letters, numbers, and symbols.");
            replies.Add("phishing -> Be cautious of emails or messages asking for personal details; verify the sender.");
            replies.Add("malware -> Avoid downloading files from unknown sources to prevent malware infections.");
            replies.Add("firewall -> Firewalls help block unauthorized access to your network.");
            replies.Add("vpn -> A VPN encrypts your internet traffic, keeping your online activity private.");
            replies.Add("encryption -> Encryption helps protect your sensitive data from unauthorized access.");
            replies.Add("2fa -> Two-Factor Authentication adds an extra layer of security to your accounts.");
            replies.Add("ransomware -> Never open suspicious attachments, and always back up your important files.");
            replies.Add("antivirus -> Keep your antivirus software updated to protect against threats.");
            replies.Add("social engineering -> Cybercriminals use manipulation to steal confidential information, stay alert.");
            replies.Add("cybersecurity -> Cybersecurity is the practice of protecting systems and data from digital attacks.");
            replies.Add("hacking -> Ethical hackers help organizations secure their systems, but illegal hacking is a crime.");
        }

        // Stores common words that should be ignored when processing user input
        private void StoreIgnore()
        {
            ignore.AddRange(new List<string>
            {
                "is", "the", "a", "an", "what", "how", "why", "when", "where", "does", "do",
                "are", "can", "could", "should", "would", "i", "me", "my", "you", "your", "we", "our"
            });
        }
    }
}