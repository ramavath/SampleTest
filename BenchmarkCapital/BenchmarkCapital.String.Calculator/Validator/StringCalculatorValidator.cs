using BenchmarkCapital.String.Calculator.Const;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BenchmarkCapital.String.Calculator.Validator
{
    public class StringCalculatorValidator : AbstractValidator<ICalculatorService>
    {

        public StringCalculatorValidator()
        {
            RuleFor(r => r).Must(IsNull);
            RuleFor(r => r).Must(IsValidDelemeter).WithMessage($"Delimeter is not mapped correctly: Correct your input");
            RuleFor(r => r).Must(IsInputHasNegativeInteger);
        }

        private bool IsValidDelemeter(ICalculatorService calculatorService)
        {

            var delemeter = calculatorService.GetDelimeters();
            var input = calculatorService.GetTruncatedInput();
            int ctr = 0;
            while (ctr < input.Length)
            {
                if (delemeter.Contains(input[ctr].ToString()))
                {
                    ++ctr;
                }

                if (ctr == input.Length)
                {
                    return true;
                } else if (input[ctr].ToString().All(char.IsDigit))
                {
                    ctr = ctr + Regex.Match(input.Substring(ctr, input.Length - ctr), @"\d+").Value.Length;
                }
                else
                {
                    return false;
                }

            }

            return true;
        }

        private bool IsNull(ICalculatorService calculatorService)
        {
            if (!string.IsNullOrEmpty(calculatorService.GetInputRequest)) return true;

            throw new Exception("Input Request is Null");
        }

        private bool IsInputHasNegativeInteger(ICalculatorService calculatorService)
        {
            var result = calculatorService.GetConvertedNumbers;
            if (!result.Any(a => a < 0)) return true;

            var negativeNumbers = string.Join(",", result.Where(w => w < 0).Select(s => s.ToString()).ToArray());
            throw new FormatException($"Negatives values are not allowed :'{negativeNumbers}'");
        }
    }
}
