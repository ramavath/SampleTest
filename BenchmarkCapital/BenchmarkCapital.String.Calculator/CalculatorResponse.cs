using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenchmarkCapital.String.Calculator
{
    public class CalculatorResponse
    {
        public int Result { get; set; } = 0;
        public StatusEnum StatusEnum { get; set; } = StatusEnum.Pass;
        public IList<string> ErrorMessages { get; set; } = new List<string>();
    }

   public enum StatusEnum
    {
        Pass,
        Fail
    }
}
