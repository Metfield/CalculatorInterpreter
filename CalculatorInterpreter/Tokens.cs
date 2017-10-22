using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorInterpreter
{
    public class Tokens
    {
        public List<char> operatorTokens;
        public List<int> operandTokens;

        public Tokens()
        {
            operatorTokens = new List<char>();
            operandTokens = new List<int>();
        }
    }
}
