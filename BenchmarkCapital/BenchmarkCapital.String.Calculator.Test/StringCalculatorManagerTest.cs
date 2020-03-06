using NUnit.Framework;

namespace BenchmarkCapital.String.Calculator.Test
{
    [TestFixture]
    public class StringCalculatorManagerTest
    {
        [Test]
        [TestCase("1\n7", ExpectedResult = 8)]
        [TestCase("1\n17", ExpectedResult = 18)]
        [TestCase("1\n1,4,5", ExpectedResult = 11)]
        [TestCase("1\n5,14", ExpectedResult = 20)]
        [TestCase("//*%\n1*2%3,1001", ExpectedResult = 6)]
        [TestCase("//*%\n1*2%3,1000", ExpectedResult = 1006)]
        [TestCase("\n", ExpectedResult = 0)]
        [TestCase("21,17,24,13", ExpectedResult = 75)]
        public  int TestWithSampleData(string inputRequest)
        {
           var resut = new StringCalculatorManager(inputRequest).ExecuteCalculation();
           return resut.Result;
        }


        [Test]
        [TestCase("1\n-14", ExpectedResult = 1)]
        [TestCase("//*%\n1*2%,3", ExpectedResult = 1)]
        public int TestWithNegative(string inputRequest)
        {
            var resut = new StringCalculatorManager(inputRequest).ExecuteCalculation();
            return (int) resut.StatusEnum;
        }

        [Test]
        [TestCase(null, ExpectedResult = 1)]
        public int TestWithNull(string inputRequest)
        {
            var resut = new StringCalculatorManager(inputRequest).ExecuteCalculation();
            return (int)resut.StatusEnum;
        }
    }
}
