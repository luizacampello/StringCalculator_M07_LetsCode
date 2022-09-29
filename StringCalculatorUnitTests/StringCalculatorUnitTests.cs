using FluentAssertions;

namespace StringCalculator.UnitTests
{
    public class StringCalculatorUnitTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void StringCalculator_NullEmptyOrWhiteSpace_ResultShouldBeZero(string entry)
        {
            var sut = new Domain.StringCalculator();

            int result = sut.Add(entry);

            Assert.Equal(0, result);
        }

        [Fact]
        public void StringCalculator_ThreeNumbersSeparatedByCommas_ShouldThrowException()
        {
            var sut = new Domain.StringCalculator();

            Action addDecimal = () => sut.Add("1,2,3");

            addDecimal.Should().Throw<ArgumentException>().WithMessage("*entryNumbers*");
        }

        [Fact]
        public void Add_WhenConsecutiveCommas_ShouldThrowException()
        {
            var sut = new Domain.StringCalculator();
            Action addDecimal = () => sut.Add("1,,3");

            addDecimal.Should().Throw<ArgumentException>().WithMessage("*entryNumbers*");
        }


        [Fact]
        public void StringCalculator_WhenContainsNonNumbers_ShouldThrowException()
        {
            var sut = new Domain.StringCalculator();

            Action addDecimal = () => sut.Add("1,a");

            addDecimal.Should().Throw<ArgumentException>().WithMessage("*entryNumbers*");
        }

        [Fact]
        public void StringCalculator_WhenValidInput_ShouldReturnSum()
        {
            var sut = new Domain.StringCalculator();

            var result = sut.Add("1,3");

            result.Should().Be(4);
        }

    }
}