using BenchmarkCapital.String.Calculator.Const;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenchmarkCapital.String.Calculator
{
    public class SingleDelimiterService : DelimiterService, ICalculatorService
    {

        
        public SingleDelimiterService(string inputRequest): base(inputRequest)
        {
           
        }

        public override IList<string> GetDelimeters()
        {
           return CommonConst.DefaultDelimiters.ToList();
        }

        public override string GetTruncatedInput()
        {
            return this.inputRequest;
        }
    }
}
