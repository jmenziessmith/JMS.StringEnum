namespace JMS.StringEnum.Tests.Unit
{
    using System.Collections.Generic;
    using FluentAssertions;
    using JMS.StringEnum.Tests.Unit.TestHelpers;
    using Xunit;

    public class StringEnumTests 
    {
        
        [Fact]
        public void AllValues_ShouldReturnFullList()
        {
            var expected = new List<string> { TestEnum.One, TestEnum.Two, TestEnum.Three };

            var result = TestEnum.AllValues;

            result.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [InlineData("One")]
        [InlineData("one")]
        [InlineData("TWO")]
        public void KnownValueTests(string value)
        {
            var enumValue = new TestEnum(value);

            enumValue.IsKnownValue().Should().BeTrue();
            TestEnum.IsKnownValue(value).Should().BeTrue();
            TestEnum.IsKnownValue(enumValue).Should().BeTrue();
        }

        [Theory]
        [InlineData("One1")]
        [InlineData("_One")]
        [InlineData("UNKNOWN")]
        public void NotKnownValueTests(string value)
        {
            var enumValue = new TestEnum(value);

            enumValue.IsKnownValue().Should().BeFalse();
            TestEnum.IsKnownValue(value).Should().BeFalse();
            TestEnum.IsKnownValue(enumValue).Should().BeFalse();
        }
    }
}
