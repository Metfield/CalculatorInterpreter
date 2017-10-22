using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorInterpreter
{
    // Just makes sure that the command is in the form
    // of operand - operator - operand - operator - operand, etc...
    class SyntaxAnalyzer
    {
        string command;

        public SyntaxAnalyzer(string command)
        {
            this.command = command;
        }

        public bool Run()
        {
            bool isExpectingOperator = false;
            char token;

            // Go through the command string
            // Basically, if we come up with more than one operator in a row, we bail
            // I realize this is a very coupled and rudimentary implementation.
            //
            // I honestly started working in the parser and when I was done, I realized I 
            // just wrote a lexical analyzer and was lacking the syntax one. Since I didn't
            // plan for this, I didn't build any useful data structure like a syntax tree or
            // anything useful I could re-use at this stage. I didn't want to start from scratch 
            // either, especially for such a small program. 
            //
            // Let's just say I know what I did, and I'm not proud of it
            for (int i = 0; i < command.Length; i++)
            {
                token = command[i];

                // Ignore white spaces
                if (Char.IsWhiteSpace(token))
                {
                    continue;
                }

                // We can take an operator now
                if(isExpectingOperator)
                {
                    // If it is an operator, next token shouldn't
                    if (IsOperator(token))
                        isExpectingOperator = false;
                }
                // We shouldn't get an operator
                else
                {
                    // ABORT!
                    if (IsOperator(token))
                        return false;
                    else
                        isExpectingOperator = true;
                }
            }

            // All went well!
            return true;
        }

        // Check if token is a valid operator
        private bool IsOperator(char token)
        {
            if (token == '+' || token == '-' || token == '*' || token == '/')
                return true;
            else
                return false;
        }
    }
}
