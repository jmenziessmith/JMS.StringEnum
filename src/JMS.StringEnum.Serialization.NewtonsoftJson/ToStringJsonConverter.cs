
namespace JMS.StringEnum.Serialization.NewtonsoftJson
{
    using System;
    using Newtonsoft.Json;

    public class ToStringJsonConverter : JsonConverter
    {
        private readonly Type type;

        public ToStringJsonConverter(Type type) => this.type = type;

        public override bool CanConvert(Type objectType)
        {
            if (this.type.IsGenericTypeDefinition)
            {
                return objectType.BaseType?.IsGenericType == true &&
                       objectType.BaseType.GetGenericTypeDefinition() == type;
            }

            return this.type == objectType;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString());
        }

        public override bool CanRead => false;

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
