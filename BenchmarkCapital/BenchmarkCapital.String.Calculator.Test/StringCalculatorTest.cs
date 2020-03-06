using NUnit.Framework;

namespace BenchmarkCapital.String.Calculator.Test
{
    [TestFixture]
    class StringCalculatorTest
    {
        [Test]
        public void TestSingleDelimeterService()
        {
            //Arrange test
            var calculatorService = new SingleDelimiterService("1\n17");
            var calculator = new StringCalculator(calculatorService);

            //Act test
            var result = calculator.PerformCalculation();

            //Assert test
             Assert.AreEqual(18, result);
        }

        [Test]
        public void TestMultiDelimeterService()
        {
            //Arrange test
            var calculatorService = new MultiDelimiterService("//*%\n1*2%3,1000");
            var calculator = new StringCalculator(calculatorService);

            //Act test
            var result = calculator.PerformCalculation();

            //Assert test
            Assert.AreEqual(1006, result);
        }
    }
}
