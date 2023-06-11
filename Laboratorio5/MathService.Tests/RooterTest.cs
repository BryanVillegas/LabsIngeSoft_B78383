using MathService;
using Xunit;

namespace MathService.Tests
{
    public class RooterTest
    {
        [Fact]
        public void BasicRooterTest()
        {
            Rooter rooter = new Rooter();

            double expectedResult = 2.0;
            double input = expectedResult * expectedResult;

            double actualResult = rooter.SquareRoot(input);

            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void RooterValueRange()
        {
            Rooter rooter = new Rooter();

            for (double expected = 1e-8; expected < 1e+8; expected *=3.2)
            {
                RooterOneValue(rooter, expected);
            }
        }

        private void RooterOneValue(Rooter rooter, double expectedResult)
        {
            double input = expectedResult * expectedResult;
            double actualResult = rooter.SquareRoot(input);
            //Assert.AreEqual(expectedResult, actualResult, delta: expectedResult / 1000);
            Assert.InRange(actualResult, expectedResult - expectedResult / 1000, expectedResult + expectedResult / 1000);
        }


        [Fact]
        public void RooterTestNegativeInput()
        {
            Rooter rooter = new Rooter();
            Assert.Throws<ArgumentOutOfRangeException>(() => rooter.SquareRoot(-1));
        }
    }
}
