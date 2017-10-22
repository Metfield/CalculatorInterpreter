using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorInterpreter
{
    class Program
    {
        static string commandInput;
        static Lexer lexer;
        static Random rand;

        static void Main(string[] args)
        {
            // Used by testing
            rand = new Random();

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Write a simple math equation in the form of operand + (operator operand), e.g. 1 + 2 * 3 ");
                ResetConsoleColor();

                // Keep trying until the command string is valid
                while (!GetConsoleCommand())
                    LogError();

                // Run syntax analysis
                SyntaxAnalyzer syntaxAnalyzer = new SyntaxAnalyzer(commandInput);

                if (!syntaxAnalyzer.Run())
                {
                    LogError();
                    continue;
                }

                // Create interpreter and run
                Interpreter interpreter = new Interpreter(lexer.GetTokens());
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("\n" + interpreter.Run() + "\n\n");
            }
        }
        
        // Reads input from CL and verifies it's valid
        private static bool GetConsoleCommand()
        {
            Console.Write("Please enter an equation (type \"test\" for random auto-input): ");

            // I generally don't like creating a new object every time but in this 
            // case it won't affect performance, plus GC will take care of this 
            commandInput = Console.ReadLine();

            // Check if it was test
            if (commandInput == "test")
            {
                rand = new Random();
                commandInput = Tests.commands[rand.Next(Tests.commands.Length)];

                Console.Write("Random test command: "  + commandInput);
            }

            // Initialize lexer with command input string
            lexer = new Lexer(commandInput);
            return lexer.Parse();
        }

       private static void LogError()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("There was an error when parsing this command, please try again \n");
            ResetConsoleColor();
        }

        private static void ResetConsoleColor()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
