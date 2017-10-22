using System;
using System.Collections.Generic;
using System.Linq;

namespace CalculatorInterpreter
{
    class Interpreter
    {
        Tokens tokens;
        Dictionary<char, string> operatorInstructions;

        // Holds result
        string interpretation;

        public Interpreter(Tokens tokens)
        {
            // Copy field
            this.tokens = tokens;

            // Initialize operator instruction dictionary
            InitializeOperatorInstructions();
        }

        private void InitializeOperatorInstructions()
        {
            // Create object
            operatorInstructions = new Dictionary<char, string>();

            // Add instructions
            operatorInstructions.Add('+', InstructionSet.ADDITION);
            operatorInstructions.Add('-', InstructionSet.SUBSTRACTION);
            operatorInstructions.Add('*', InstructionSet.MULTIPLICATION);
            operatorInstructions.Add('/', InstructionSet.DIVISION);
        }

        public string Run()
        {
            // First element is always an operand
            interpretation += InstructionSet.PUSH + " " + tokens.operandTokens[0] + Environment.NewLine;

            // Start with second operand
            for (int i = 1; i < tokens.operandTokens.Count(); i++)
            {
                // Push operand
                interpretation += InstructionSet.PUSH + " " + tokens.operandTokens[i] + Environment.NewLine;

                // Execute operator instruction
                interpretation += operatorInstructions[tokens.operatorTokens[i - 1]] + Environment.NewLine;
            }

            // Finally add PRINT instruction
            interpretation += InstructionSet.PRINT + Environment.NewLine;

            // Return!
            return interpretation;
        }
    }
}
