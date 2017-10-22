using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorInterpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("There was an error when parsing this command, please try again \n");
            ResetConsoleColor();

            // Keep trying until the command string is valid
            while (!GetConsoleCommand())
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("There was an error when parsing this command, please try again \n");
                ResetConsoleColor();
            }


        }
        
        // Reads input from CL and verifies it's valid
        private static bool GetConsoleCommand()
        {
            Console.Write("Please enter an equation: ");

            // I generally don't like creating a new object every time but in this 
            // case it won't affect performance, plus GC will take care of this 
            Lexer lexer = new Lexer(Console.ReadLine());
            return lexer.Parse();
        }

       
        private static void ResetConsoleColor()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
