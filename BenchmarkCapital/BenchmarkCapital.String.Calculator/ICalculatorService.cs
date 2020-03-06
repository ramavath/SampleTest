using System.Collections.Generic;

namespace BenchmarkCapital.String.Calculator
{
    public interface ICalculatorService
    {
        IList<int> GetConvertedNumbers { get; }
        IList<string> GetDelimeters();
        string GetNegativeNumbers { get; }
        string GetInputRequest { get; }
        string GetTruncatedInput();
    }
}