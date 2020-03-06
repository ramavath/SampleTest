using System;
using BenchmarkCapital.String.Calculator.Const;
using BenchmarkCapital.String.Calculator.Validator;

namespace BenchmarkCapital.String.Calculator
{
    public class StringCalculatorManager
    {
        private readonly IStringCalculator stringCalculator;
        private readonly ICalculatorService calculatorService;
        public StringCalculatorManager(string inputRequest)
        {
            this.calculatorService = GetDelemeterServie(inputRequest);
            this.stringCalculator = new StringCalculator(this.calculatorService);
        }

        private ICalculatorService GetDelemeterServie(string inputRequest)
        {

            if (!string.IsNullOrEmpty(inputRequest) && inputRequest.StartsWith(CommonConst.MultiDelimiterIdentifier))
            {
                return new MultiDelimiterService(inputRequest);
            }
            else
            {

                return new SingleDelimiterService(inputRequest);
            }
        }

        public CalculatorResponse ExecuteCalculation()
        {
            var response = CreateCalculatorResponse();
            try
            {
                var validation = new StringCalculatorValidator().Validate(this.calculatorService);
                if (validation.IsValid)
                {
                    response.Result = this.stringCalculator.PerformCalculation();
                    response.StatusEnum = StatusEnum.Pass;
                }
                else
                {
                    response.StatusEnum = StatusEnum.Fail;
                    foreach (var item in validation.Errors)
                    {
                        response.ErrorMessages.Add(item.ErrorMessage);

                    }
                }
            }
            catch (Exception ex)
            {

                response.ErrorMessages.Add("Exception Occured in Calculation Manager, Error: " + ex.Message);
                response.StatusEnum = StatusEnum.Fail;
            }

            return response;

        }

        private CalculatorResponse CreateCalculatorResponse()
        {
            return new CalculatorResponse();
        }
    }
}
