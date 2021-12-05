namespace JMS.StringEnum.Serialization.NewtonsoftJson.Tests.Unit.TestHelpers
{
    using System.Collections.Generic;

    public class TestModel
    {
        public TestEnum ExampleValue { get; set; }

        public Dictionary<TestEnum, string> ExampleDictionary { get; set; }
    }
    
}
