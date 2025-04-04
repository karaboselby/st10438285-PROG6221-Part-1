using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CybersecurityChatbot
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.Title = "Cybersecurity Awareness Chatbot";
            DisplayAsciiArt();
            PlayWelcomeMessage();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Please enter your name: ");
            Console.ResetColor();
            string userName = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(userName))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Name cannot be empty. Please enter your name: ");
                Console.ResetColor();
                userName = Console.ReadLine();
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\n══════════════════════════════════════════════════════════");
            Console.WriteLine($" Welcome, {userName}, to the Cybersecurity Awareness Chatbot!");
            Console.WriteLine($"══════════════════════════════════════════════════════════\n");
            Thread.Sleep(500);
            Console.WriteLine("I am here to help you stay safe online. Ask me about:");
            Console.WriteLine("🔹 Passwords  🔹 Phishing  🔹 Malware  🔹 Wi-Fi  🔹 Social Media");
            Console.WriteLine("══════════════════════════════════════════════════════════\n");
            Console.ResetColor();

            Dictionary<string, string> responses = new Dictionary<string, string>
        {
            { "passwords", "\n🛡️ Use strong, unique passwords and enable two-factor authentication where possible." },
            { "phishing", "\n⚠️ Be cautious of emails or messages asking for personal information. Verify links before clicking." },
            { "malware", "\n🦠 Keep your software updated and use reputable antivirus programs to prevent malware infections." },
            { "wifi", "\n📡 Avoid using public Wi-Fi for sensitive transactions. Use a VPN for added security." },
            { "social media", "\n🔐 Limit sharing personal information online and adjust privacy settings for better security." },
            { "how are you", $"\n🤖 I'm just a chatbot, {userName}, but I'm always ready to help you with cybersecurity tips!" },
            { "what's your purpose", $"\n🎯 My purpose is to educate and assist you with cybersecurity awareness, {userName}. Ask me about passwords, phishing, and safe browsing!" },
            { "what can i ask you about", $"\n💡 You can ask me about topics like passwords, phishing, malware, Wi-Fi security, and social media safety, {userName}." }
        };

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"{userName}, ask a cybersecurity question (or type 'exit' to quit): ");
                Console.ResetColor();
                string input = Console.ReadLine()?.Trim().ToLower();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n⚠️ You didn't enter anything. Please ask a cybersecurity question!\n");
                    Console.ResetColor();
                    continue;
                }

                if (input == "exit")
                {
                    Console.WriteLine($"\n✅ Thank you for using the chatbot, {userName}. Stay safe online!\n");
                    break;
                }
                else if (responses.ContainsKey(input))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(responses[input]);
                    Console.ResetColor();
                    Thread.Sleep(1000);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n❓ I didn’t quite understand that, {userName}. Could you rephrase? Try asking about passwords, phishing, malware, Wi-Fi, or social media.\n");
                    Console.ResetColor();
                    Thread.Sleep(1000);
                }
            }
        }

        static void DisplayAsciiArt()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(@"  ____      _                 _              _        _    _           _   ");
            Console.WriteLine(@" / ___|   _| |__   ___  _   _| |__   ___  ___| |_     | |  | | ___  ___| |_ ");
            Console.WriteLine(@"| |  | | | | '_ \ / _ \| | | | '_ \ / _ \/ __| __|    | |  | |/ _ \/ __| __|");
            Console.WriteLine(@"| |__| |_| | |_) | (_) | |_| | |_) |  __/\__ \ |_     | |__| |  __/\__ \ |_ ");
            Console.WriteLine(@" \____\__,_|_.__/ \___/ \__,_|_.__/ \___||___/\__|     \____/ \___||___/\__|");
            Console.WriteLine();
            Console.ResetColor();
        }

        static void PlayWelcomeMessage()
        {
            try
            {
                using (SoundPlayer player = new SoundPlayer("cybersecurity_welcome.wav"))
                {
                    player.PlaySync();
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error playing welcome message: " + ex.Message);
                Console.ResetColor();
            }
        }
    }
}
    

