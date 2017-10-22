using System.Collections.Generic;

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
