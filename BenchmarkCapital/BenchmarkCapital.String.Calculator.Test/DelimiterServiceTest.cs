using NUnit.Framework;

namespace BenchmarkCapital.String.Calculator.Test
{
    [TestFixture]
    public class DelimiterServiceTest
    {
        [Test]
        public void TestSingleDelimiterService()
        {
            //Arrange test
            var calculatorService = new SingleDelimiterService("1\n17");
           

            // Act test
            var result = calculatorService.GetDelimeters();

            //Assert test
            Assert.AreEqual(",", result[0]);
        }
        [Test]
        public void TestMultiDelimiterService()
        {
            //Arrange test
            var calculatorService = new MultiDelimiterService("//*%\n1*2%3,1000");

            // Act test
            var result = calculatorService.GetDelimeters();

            //Assert test
            Assert.AreEqual("*", result[0]);
        }
    }
}
