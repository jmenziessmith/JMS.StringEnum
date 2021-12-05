namespace JMS.StringEnum.Tests.Unit
{
    using AutoFixture.Xunit2;
    using FluentAssertions;
    using JMS.StringEnum.Tests.Unit.TestHelpers;
    using Xunit;

    public class HashCodeTests
    {


        [Theory]
        [AutoData]
        public void GetHashCode_ReturnsSameValue(string value)
        {
            TestEnum enumValue = value;

            enumValue.GetHashCode().Should().Equals(value.GetHashCode());
        }
    }
}
