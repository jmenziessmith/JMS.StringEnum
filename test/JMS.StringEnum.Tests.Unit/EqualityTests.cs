namespace JMS.StringEnum.Tests.Unit
{
    using AutoFixture.Xunit2;
    using FluentAssertions;
    using JMS.StringEnum.Tests.Unit.TestHelpers;
    using Xunit;

    public class EqualityTests
    {
        [Theory]
        [AutoData]
        public void Equality_ShouldEvaluateCorrectly(string value)
        {
            var left = new TestEnum(value);
            TestEnum right = value;

            (left == right).Should().BeTrue();
            (right == left).Should().BeTrue();

            (left == value).Should().BeTrue();
            (right == value).Should().BeTrue();
            (value == left).Should().BeTrue();
            (value == right).Should().BeTrue();
            value.Equals(left).Should().BeTrue();
            value.Equals(right).Should().BeTrue();

            (TestEnum.Three == "Number3").Should().BeTrue();
        }

        [Theory]
        [AutoData]
        public void Inequality_ShouldEvaluateCorrectly(string value1, string value2)
        {
            var left = new TestEnum(value1);
            TestEnum right = value2;

            (left == right).Should().BeFalse();
            (right == left).Should().BeFalse();

            (left == value2).Should().BeFalse();
            (right == value1).Should().BeFalse();
            (value2 == left).Should().BeFalse();
            (value1 == right).Should().BeFalse();
            value2.Equals(left).Should().BeFalse();
            value1.Equals(right).Should().BeFalse();

            (TestEnum.Three == "Three").Should().BeFalse();
        }

    }
}
