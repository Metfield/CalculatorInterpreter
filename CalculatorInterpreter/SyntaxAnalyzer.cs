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
            return true;
        }
    }
}
