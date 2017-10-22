using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CalculatorInterpreter
{
    class Lexer
    {
        string command;
        char[] supportedOperators = { '+', '-', '*', '/' };
        Tokens tokens;

        public Lexer(string command)
        {
            // Assign field
            this.command = command;

            // Create objects
            tokens = new Tokens();
        }

        public bool Parse()
        {
            // Trim whitespaces at the start or end of the command string
            command = command.Trim();

            // Extract operators from command string
            if (!ExtractOperators())
                return false;

            // Extract operands from rest of the string
            if (!ExtractOperands())
                return false;

            // We should always have one more operand
            if ((tokens.operandTokens.Count() - tokens.operatorTokens.Count()) != 1)
                return false;

            // Alles ist gut hier! (did I mention I'm a clown?)
            return true;
        }

        private bool ExtractOperators()
        {
            StringBuilder stringBuilder;
            int operatorIndex = 0;

            // Iterate through command and separate operators from string
            while ((operatorIndex = command.IndexOfAny(supportedOperators)) != -1)
            {
                // Command can't start with operator
                if (operatorIndex == 0)
                    return false;

                // Add operator to list
                tokens.operatorTokens.Add(command[operatorIndex]);

                // Remove from string
                stringBuilder = new StringBuilder(command);
                stringBuilder[operatorIndex] = ' ';
                command = stringBuilder.ToString();
            }

            // All went well
            return true;
        }

        private bool ExtractOperands()
        {
            // Create operands list
            tokens.operandTokens = new List<int>();

            // Get rid of extra white spaces in command string
            command = Regex.Replace(command, @"\s+", " ");

            // Separate operands into different strings
            string[] operands = command.Split(' ');

            // Add each of these to the list
            // We're doing this "double-work" and integer conversion
            // to make sure that the operands are indeed numbers
            // we wouldn't like to add 'p' to 1
            foreach (string operandString in operands)
            {
                int operand;

                // Parse the string operand into an integer
                if (!Int32.TryParse(operandString, out operand))
                    return false;

                // Add to operand list
                tokens.operandTokens.Add(operand);
            }

            // Everything went well!
            return true;
        }

        public Tokens GetTokens()
        {
            return tokens;
        }
    }
}
