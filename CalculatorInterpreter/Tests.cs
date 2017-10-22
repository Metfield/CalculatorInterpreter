using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorInterpreter
{
    public static class Tests
    {
        public static string[] commands = { "1 + 2 - 3",
                                            "10 / 25",
                                            "10 * 100 / 5 - 30",
                                            "     23  +86    / 80",
                                            "5+       89*7",
                                            "     75/98       +861"};
    }
}
