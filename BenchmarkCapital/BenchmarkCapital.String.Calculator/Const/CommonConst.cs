using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenchmarkCapital.String.Calculator.Const
{
    public static class CommonConst
    {
        public static IList<string> DefaultDelimiters = new List<string> { ",", "\n" };
        public static IEnumerable<char> DefaultDelimitersCharArray = new char[] { ',', '\n' };
        public static int MaxLimit = 1000;
        public static int Two = 2;
        public static string MultiDelimiterIdentifier = "//";
        public static string NewLine = "\n";
    }
}
