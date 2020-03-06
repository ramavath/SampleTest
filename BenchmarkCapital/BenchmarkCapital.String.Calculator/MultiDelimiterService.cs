using BenchmarkCapital.String.Calculator.Const;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenchmarkCapital.String.Calculator
{
    public class MultiDelimiterService : DelimiterService, ICalculatorService
    {
        
        public MultiDelimiterService(string inputRequest) : base(inputRequest)
        {
 
        }
     
        public override IList<string> GetDelimeters()
        {
                var result = inputRequest.Substring(CommonConst.Two, inputRequest.IndexOf(CommonConst.NewLine) - CommonConst.Two);
                if (result.Contains('['))
                {
                    var Delimiters = result.Split('[').Select(x => x.TrimEnd(']')).Where(w => w != string.Empty).ToList();
                    Delimiters.AddRange(CommonConst.DefaultDelimiters.ToList());
                    return Delimiters;
                }
                var delimters = result.ToArray().ToList().Select(s => s.ToString()).ToList();
                delimters.AddRange(CommonConst.DefaultDelimiters.ToList());
                return delimters;
        }

         public override string GetTruncatedInput()
        {
           return this.inputRequest.Substring(GetDelimeters().Count, this.inputRequest.Length - GetDelimeters().Count);
        }
    }
}

