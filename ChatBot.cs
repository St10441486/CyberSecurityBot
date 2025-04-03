using System;

namespace CyberSecurityBot
{
    // Main ChatBot class
    public class ChatBot
    {
        private string name;
        private AudioImageHandler mediaHandler;
        private QuestionHandler questionHandler;

        // Constructor initializes media and question handling components
        public ChatBot()
        {
            mediaHandler = new AudioImageHandler();
            questionHandler = new QuestionHandler();
        }

        // Runs the chatbot, displaying the logo, playing welcome audio, and prompting user interaction
        public void Run()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            ShowLoading();
            mediaHandler.DisplayLogo();
            mediaHandler.PlayWelcomeAudio();
            WelcomeUser();
            Menu();
        }

        // Displays a simple loading animation before the chatbot starts
        private void ShowLoading(int seconds = 3)
        {
            Console.Write("\n Starting up chatbot AI");
            for (int i = 0; i < seconds; i++)
            {
                Console.Write(".");
                System.Threading.Thread.Sleep(1000);
            }
            Console.WriteLine();
        }

        // Prompts user for their name and greets them
        private void WelcomeUser()
        {
            Console.WriteLine("\n===================================================================================================");
            Console.WriteLine("CHAT AI-> Hello! Welcome to the Cybersecurity Awareness Bot. I'm here to help you stay safe online.");
            Console.WriteLine("===================================================================================================");
            Console.WriteLine("Chat AI-> Please enter your full name:");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("User-> ");
            name = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n===================================================================================================");
            Console.WriteLine("Chat AI-> Your full name is: " + name);
            Console.WriteLine("===================================================================================================");
        }

        // Displays the main menu and handles user interactions
        private void Menu()
        {
            while (true)
            {
                Console.WriteLine("\n===================================================================================================");
                Console.WriteLine("Chat AI-> Would you like to ask any questions? (yes/no)");
                Console.WriteLine("===================================================================================================");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(name + "-> ");
                string answer = Console.ReadLine()?.ToLower();
                Console.ForegroundColor = ConsoleColor.Cyan;

                // Handles user input for asking questions or exiting the chatbot
                switch (answer)
                {
                    case "yes":
                        questionHandler.HandleQuestions(name);
                        break;
                    case "no":
                        Console.WriteLine("\n===================================================================================================");
                        Console.WriteLine("That's a shame. Feel free to come back if you have questions.");
                        Console.WriteLine("===================================================================================================");
                        return;
                    default:
                        Console.WriteLine("\n===================================================================================================");
                        Console.WriteLine("Invalid input! Please enter 'yes' or 'no'.");
                        Console.WriteLine("===================================================================================================");
                        break;
                }
            }
        }
    }
}
