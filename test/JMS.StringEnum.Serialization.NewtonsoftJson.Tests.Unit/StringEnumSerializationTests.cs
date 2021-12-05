using FluentAssertions;
using JMS.StringEnum.Serialization.NewtonsoftJson.Tests.Unit.TestHelpers;
using Newtonsoft.Json;
using System.Collections.Generic;
using Xunit;

namespace JMS.StringEnum.Serialization.NewtonsoftJson.Tests.Unit
{
    public class StringEnumSerializationTests
    {
        JsonSerializerSettings jsonSettings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore
        }.ConfigureStringEnum();

        [Fact]
        public void SerializationTests()
        {
            var json = "{\"ExampleValue\":\"One\"}";

            var value = new TestModel
            {
                ExampleValue = TestEnum.One,
            };

            var serialized = JsonConvert.SerializeObject(value, jsonSettings);

            serialized.Should().Be(json);

            // check if the default serialization settings are not specified, then it at least contains the value.
            JsonConvert.SerializeObject(value).Should().Contain("One");
        }

        [Fact]
        public void DictionarySerializationTests()
        {
            var json = "{\"ExampleDictionary\":{\"One\":\"1\",\"Two\":\"2\",\"Number3\":\"3\"}}";

            var value = new TestModel
            {
                ExampleDictionary = new Dictionary<TestEnum, string>
                {
                    { TestEnum.One, "1" },
                    { TestEnum.Two, "2" },
                    { TestEnum.Three, "3" },
                },
            };

            var serialized = JsonConvert.SerializeObject(value, jsonSettings);

            serialized.Should().Be(json);
        }

        [Theory]
        [InlineData("{\"exampleValue\":\"One\"}")]
        [InlineData("{\"exampleValue\": { \"Value\" : \"One\" } }")]
        public void DeSerializationTests(string json)
        {
            var expected = new TestModel
            {
                ExampleValue = TestEnum.One,
            };

            var deserialized = JsonConvert.DeserializeObject<TestModel>(json, jsonSettings);

            deserialized.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [InlineData("{\"exampleDictionary\":{\"one\":\"1\",\"two\":\"2\",\"number3\":\"3\"}}")]
        [InlineData("{\"exampleDictionary\":{\"one\":\"1\",\"two\":\"2\",\"UNKNOWN\":\"3\"}}")]
        public void DictionaryDeSerializationTests(string json)
        {
            var expected = new TestModel
            {
                ExampleDictionary = new Dictionary<TestEnum, string>
                {
                    { TestEnum.One, "1" },
                    { TestEnum.Two, "2" },
                    { json.Contains("UNKNOWN") ? "UNKNOWN" : (string)TestEnum.Three, "3" },
                },
            };
            var deserialized = JsonConvert.DeserializeObject<TestModel>(json, jsonSettings);

            deserialized.Should().BeEquivalentTo(expected);
        }
    }
}
