namespace JMS.StringEnum.Tests.Unit.TestHelpers
{
    public class TestEnum : StringEnum<TestEnum>
    {
        public const string One = nameof(One);

        public const string Three = "Number3";

        public TestEnum(string value)
            : base(value)
        {
        }

        public static string Two => new TestEnum(nameof(Two));

        public static implicit operator TestEnum(string val) => new TestEnum(val);
    }
}
