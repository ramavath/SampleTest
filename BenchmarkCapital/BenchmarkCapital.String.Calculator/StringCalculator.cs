using BenchmarkCapital.String.Calculator.Const;
using System.Linq;

namespace BenchmarkCapital.String.Calculator
{
   
    public class StringCalculator : IStringCalculator
    {
        private readonly ICalculatorService calculatorService;

        public StringCalculator(ICalculatorService calculatorService)
        {
            this.calculatorService = calculatorService;
        }

        public int PerformCalculation()
        {
               return this.calculatorService.GetConvertedNumbers.Where(w => w <= CommonConst.MaxLimit).Sum();
        }
    }
   }
