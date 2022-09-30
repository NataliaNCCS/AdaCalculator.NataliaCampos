using AdaCalculator;
using Moq;
using Shouldly;
using Xunit;

namespace AdaCalculatorTests
{
    public class CalculatorTest
    {
        private readonly CalculatorMachine calculatorMachine;
        private readonly CalculatorMachine sut;
        private readonly Mock<ICalculator> mockCalculator;
        public CalculatorTest()
        {
            calculatorMachine = new CalculatorMachine();
            mockCalculator = new Mock<ICalculator>();
            sut = new CalculatorMachine(mockCalculator.Object);
        }

        [Theory]
        [InlineData("sum", 1.23, 13, 14.23)]
        [InlineData("sum", 4, 0, 4)]
        [InlineData("sum", 12, -1, 11)]
        [InlineData("sum", 10, 13, 23)]
        [InlineData("sum", 0, -100, -100)]
        [InlineData("sum", 10, -1.5, 8.5)]
        public void Test_Sum_TwoNumbers(string op, double a, double b, double res)
        {
            var opResult = calculatorMachine.Calculate(op, a, b);

            opResult.ShouldBe(("sum", res));
        }

        [Theory]
        [InlineData("sum", 1.23, 13, 14.23)]
        [InlineData("sum", 4, 0, 4)]
        [InlineData("sum", 12, -1, 11)]
        [InlineData("sum", 10, 13, 23)]
        [InlineData("sum", 0, -100, -100)]
        [InlineData("sum", 10, -1.5, 8.5)]
        public void TestMock_Sum_TwoNumbers(string op, double a, double b, double res)
        {
            mockCalculator.Setup(x => x.Calculate(It.IsAny<string>(), It.IsAny<double>(), It.IsAny<double>())).Returns((op, res));

            var opResult = sut.Calculate(op, a, b);

            mockCalculator.Verify(x => x.Calculate(op, a, b), Times.Once);

            Assert.Equal(op, opResult.operation);
            Assert.Equal(res, opResult.result);
        }



        [Theory]
        [InlineData("multiply", 2, 3, 6)]
        [InlineData("multiply", 2, -1, -2)]
        [InlineData("multiply", 10, 0, 0)]
        [InlineData("multiply", 2, 2.5, 5)]
        public void Test_Multiply_TwoNumbers(string op, double a, double b, double res)
        {
            var opResult = calculatorMachine.Calculate(op, a, b);

            opResult.ShouldBe(("multiply", res));
        }

        [Theory]
        [InlineData("multiply", 2, 3, 6)]
        [InlineData("multiply", 2, -1, -2)]
        [InlineData("multiply", 10, 0, 0)]
        [InlineData("multiply", 2, 2.5, 5)]
        public void TestMock_Multiply_TwoNumbers(string op, double a, double b, double res)
        {
            mockCalculator.Setup(x => x.Calculate(It.IsAny<string>(), It.IsAny<double>(), It.IsAny<double>())).Returns((op, res));
            var opResult = sut.Calculate(op, a, b);

            mockCalculator.Verify(x => x.Calculate(op, a, b), Times.Once);

            Assert.Equal(op, opResult.operation);
            Assert.Equal(res, opResult.result);
        }



        [Theory]
        [InlineData("subtract", 2, 3, -1)]
        [InlineData("subtract", 2, 0, 2)]
        [InlineData("subtract", 10, 1, 9)]
        [InlineData("subtract", -10, 2.5, -12.5)]
        public void Test_Subtract_TwoNumbers(string op, double a, double b, double res)
        {
            var opResult = calculatorMachine.Calculate(op, a, b);

            opResult.ShouldBe(("subtract", res));
        }

        [Theory]
        [InlineData("subtract", 2, 3, -1)]
        [InlineData("subtract", 2, 0, 2)]
        [InlineData("subtract", 10, 1, 9)]
        [InlineData("subtract", -10, 2.5, -12.5)]
        public void TestMock_Subtract_TwoNumbers(string op, double a, double b, double res)
        {
            mockCalculator.Setup(x => x.Calculate(It.IsAny<string>(), It.IsAny<double>(), It.IsAny<double>())).Returns((op, res));
            var opResult = sut.Calculate(op, a, b);

            mockCalculator.Verify(x => x.Calculate(op, a, b), Times.Once);

            Assert.Equal(op, opResult.operation);
            Assert.Equal(res, opResult.result);
        }



        [Theory]
        [InlineData("divide", 6, 3, 2)]
        [InlineData("divide", 2, 0, double.PositiveInfinity)]
        [InlineData("divide", 10, -1, -10)]
        [InlineData("divide", -10, 2.5, -4)]
        [InlineData("divide", -10, -2, 5)]
        public void Test_Divide_TwoNumbers(string op, double a, double b, double res)
        {
            var opResult = calculatorMachine.Calculate(op, a, b);

            opResult.ShouldBe(("divide", res));
        }

        [Theory]
        [InlineData("divide", 6, 3, 2)]
        [InlineData("divide", 2, 0, double.PositiveInfinity)]
        [InlineData("divide", 10, -1, -10)]
        [InlineData("divide", -10, 2.5, -4)]
        [InlineData("divide", -10, -2, 5)]
        public void TestMock_Divide_TwoNumbers(string op, double a, double b, double res)
        {
            mockCalculator.Setup(x => x.Calculate(It.IsAny<string>(), It.IsAny<double>(), It.IsAny<double>())).Returns((op, res));
            var opResult = sut.Calculate(op, a, b);

            mockCalculator.Verify(x => x.Calculate(op, a, b), Times.Once);

            Assert.Equal(op, opResult.operation);
            Assert.Equal(res, opResult.result);
        }
    }
}