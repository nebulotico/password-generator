using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace password_generator
{
    internal class Program
    {
        static int size = 8;
        static bool ucase = true;
        static bool lcase = true;
        static bool num = true;
        static bool sym = true;
        static void Main(string[] args)
        {
            Console.Title = "Atomo -> Password Generator";
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine(@"
██████╗  █████╗ ███████╗███████╗██╗    ██╗ ██████╗ ██████╗ ██████╗           
██╔══██╗██╔══██╗██╔════╝██╔════╝██║    ██║██╔═══██╗██╔══██╗██╔══██╗          
██████╔╝███████║███████╗███████╗██║ █╗ ██║██║   ██║██████╔╝██║  ██║          
██╔═══╝ ██╔══██║╚════██║╚════██║██║███╗██║██║   ██║██╔══██╗██║  ██║          
██║     ██║  ██║███████║███████║╚███╔███╔╝╚██████╔╝██║  ██║██████╔╝          
╚═╝     ╚═╝  ╚═╝╚══════╝╚══════╝ ╚══╝╚══╝  ╚═════╝ ╚═╝  ╚═╝╚═════╝           
                                                                             
 ██████╗ ███████╗███╗   ██╗███████╗██████╗  █████╗ ████████╗ ██████╗ ██████╗ 
██╔════╝ ██╔════╝████╗  ██║██╔════╝██╔══██╗██╔══██╗╚══██╔══╝██╔═══██╗██╔══██╗
██║  ███╗█████╗  ██╔██╗ ██║█████╗  ██████╔╝███████║   ██║   ██║   ██║██████╔╝
██║   ██║██╔══╝  ██║╚██╗██║██╔══╝  ██╔══██╗██╔══██║   ██║   ██║   ██║██╔══██╗
╚██████╔╝███████╗██║ ╚████║███████╗██║  ██║██║  ██║   ██║   ╚██████╔╝██║  ██║
 ╚═════╝ ╚══════╝╚═╝  ╚═══╝╚══════╝╚═╝  ╚═╝╚═╝  ╚═╝   ╚═╝    ╚═════╝ ╚═╝  ╚═╝   
                                                             
Telegram: @Mahitozin
Github: https://github.com/Mahitozin
");
                Console.ResetColor();

                log($"0 -> Password length: {size}", ConsoleColor.Gray);
                logbool("1 -> Uppercase", ucase, "ENABLED", "DISABLED");
                logbool("2 -> Lowercase", lcase, "ENABLED", "DISABLED");
                logbool("3 -> Numbers  ", num, "ENABLED", "DISABLED");
                logbool("4 -> Symbols  ", sym, "ENABLED", "DISABLED");
                log("5 -> Generate Password\n", ConsoleColor.Gray);


                string escolha = input("Action -> ");
                if (escolha == "0")
                {
                i:
                    try
                    {
                        size = int.Parse(input("New password length -> "));
                    }
                    catch { goto i; }
                }
                else if (escolha == "1")
                { ucase = !ucase; }
                else if (escolha == "2")
                { lcase = !lcase; }
                else if (escolha == "3")
                { num = !num; }
                else if (escolha == "4")
                { sym = !sym; }
                else if (escolha == "5")
                { generate(); }
                else
                {
                    log("Invalid action", ConsoleColor.DarkRed);
                }
            }
        }

        static void generate()
        {
            string wl = "";
            if (ucase)
                wl += "ABCDEFGHIJKLMNOPQRSTUWXYZ";
            if (lcase)
                wl += "abcdefghijklmnopqrstuwxyz";
            if (num)
                wl += "0123456789";
            if (sym)
                wl += "~!@#$%^&*()_-+=.?";

            string pass = "";
            Random rnd = new Random();
            for (int x = 0; x != size; x++)
            {
                pass += wl[rnd.Next(wl.Length)];
            }
            log($"Password -> {pass}", ConsoleColor.Gray);
            Console.ReadLine();
        }

        static void logbool(string msg, bool value, string on, string off)
        {
            string txt = value ? on : off;
            ConsoleColor cb = Console.ForegroundColor;
            ConsoleColor bc = Console.ForegroundColor;
            if (value)
                bc = ConsoleColor.DarkGreen;
            else
                bc = ConsoleColor.DarkRed;

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write($"[{DateTime.Now.ToString("hh:mm:ss")}] ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(msg + " [");
            Console.ForegroundColor = bc;
            Console.Write($"{txt}");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("]");
            Console.ForegroundColor = cb;
        }

        static string input(string msg)
        {
            ConsoleColor cb = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write($"[{DateTime.Now.ToString("hh:mm:ss")}] ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(msg);
            Console.ForegroundColor = cb;

            return Console.ReadLine();
        }

        static void log(string msg, ConsoleColor cor)
        {
            ConsoleColor cb = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write($"[{DateTime.Now.ToString("hh:mm:ss")}] ");
            Console.ForegroundColor = cor;
            Console.WriteLine(msg);
            Console.ForegroundColor = cb;
        }
    }
}
