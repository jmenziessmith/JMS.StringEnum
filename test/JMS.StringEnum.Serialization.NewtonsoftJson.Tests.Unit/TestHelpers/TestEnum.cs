namespace JMS.StringEnum.Serialization.NewtonsoftJson.Tests.Unit.TestHelpers
{
    public class TestEnum : StringEnum<TestEnum>
    {
        public static TestEnum One => nameof(One);

        public static TestEnum Two = new TestEnum(nameof(Two));

        public static TestEnum Three = "Number3";

        public const string Four = "Four";

        public TestEnum(string value)
            : base(value)
        {
        }

        public static implicit operator TestEnum(string val) => new TestEnum(val);
    }
}
