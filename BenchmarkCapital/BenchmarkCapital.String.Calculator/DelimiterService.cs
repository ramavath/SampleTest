using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenchmarkCapital.String.Calculator
{
    public abstract class DelimiterService
    {
        protected readonly string inputRequest;
        public DelimiterService(string inputRequest)
        {
            this.inputRequest = inputRequest;
        }
        public string GetInputRequest
        {
            get
            {
                return this.inputRequest;
            }
        }
        public IList<int> GetConvertedNumbers
        {
            get
            {
                return GetTruncatedInput().Split(GetDelimeters().ToArray(), StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            }
        }

        public string GetNegativeNumbers
        {
            get
            {
                return string.Join(",", this.inputRequest.Where(w => w < 0).Select(s => s.ToString()).ToArray());
            }
        }
        public abstract IList<string> GetDelimeters();

        public abstract string GetTruncatedInput();
    }
}
