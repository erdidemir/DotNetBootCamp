using Xunit;
using XUnitSample;

namespace CalculatorUnitTest
{
    public class CalculatorTest
    {
        [Fact]
        public void Be_able_to_add_two_numbers()
        {
            // Arrange
            int number1 = 5;
            int number2 = 15;
            Calculator sut = new Calculator();
            // Act
            int result = sut.Addition(number1, number2);
            // Assert
            Assert.Equal(20, result);
        }
    }
}