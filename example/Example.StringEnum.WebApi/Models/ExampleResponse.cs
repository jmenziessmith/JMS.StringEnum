namespace Example.StringEnum.WebApi
{
    public class ExampleResponse
    {
        public string StringValue { get; set; }

        public MyEnum EnumValue { get; set; }

        public bool IsEnumValueKnown { get; set; }
    }

}
