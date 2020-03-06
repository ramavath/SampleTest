using BenchmarkCapital.String.Calculator.Validator;
using NUnit.Framework;

namespace BenchmarkCapital.String.Calculator.Test
{
    [TestFixture]
    class StringValidatorTest
    {
        [Test]
        public void TestStringValidatorValue()
        {
            //Arrange test
            var calculatorService = new SingleDelimiterService("1\n17");
            var validator = new StringCalculatorValidator();

           // Act test
            var result = validator.Validate(calculatorService);

            //Assert test
            Assert.AreEqual(true, result.IsValid);
        }

        [Test]
        public void TestStringValidatorWithNegative()
        {
            //Arrange test
            var calculatorService = new SingleDelimiterService("1,\n14");
            var validator = new StringCalculatorValidator();

            // Act test
            var result = validator.Validate(calculatorService);

            //Assert test
            Assert.AreEqual("Delimeter is not mapped correctly: Correct your input", result.Errors[0].ErrorMessage);
        }
    }
}
