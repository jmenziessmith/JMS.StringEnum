namespace JMS.StringEnum.Tests.Unit
{
    using FluentAssertions;
    using JMS.StringEnum.Tests.Unit.TestHelpers;
    using Xunit;

    public class ConversionTests 
    {

        [Fact]
        public void ConvertingFromString_UsingContructor_ShouldMatchOnKnownValues()
        {
            var stringValue = "NUMBER3";

            var enumValue1 = new TestEnum(stringValue);

            enumValue1.IsKnownValue().Should().BeTrue();
            enumValue1.ToString().Should().Be("Number3");
        }

        [Fact]
        public void ConvertingFromString_UsingImplicitConversion_ShouldMatchOnKnownValues()
        {
            var stringValue = "NUMBER3";

            TestEnum enumValue2 = stringValue;

            enumValue2.IsKnownValue().Should().BeTrue();
            enumValue2.ToString().Should().Be("Number3");
        }

        [Fact]
        public void ConvertingFromString_UsingCasting_ShouldMatchOnKnownValues()
        {
            var stringValue = "NUMBER3";

            var enumValue3 = (TestEnum)stringValue;

            enumValue3.IsKnownValue().Should().BeTrue();
            enumValue3.ToString().Should().Be("Number3");
        }


        [Fact]
        public void ConvertingToString_UsingToString_ShouldReturnStringValue()
        {
            TestEnum enumValue = TestEnum.Three;

            string stringValue = enumValue.ToString();

            stringValue.Should().Be("Number3");
        }

        [Fact] 
        public void ConvertingToString_UsingImplicitConversion_ShouldReturnStringValue()
        {
            TestEnum enumValue = TestEnum.Three;

            string stringValue = enumValue;

            stringValue.Should().Be("Number3");
        }


        [Fact]
        public void ConvertingToString_UsingCasting_ShouldReturnStringValue()
        {
            TestEnum enumValue = TestEnum.Three;

            string stringValue = (string)enumValue;

            stringValue.Should().Be("Number3");
        }
    }
}
