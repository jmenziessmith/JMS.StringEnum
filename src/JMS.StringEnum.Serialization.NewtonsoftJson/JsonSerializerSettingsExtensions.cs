using Newtonsoft.Json;

namespace JMS.StringEnum.Serialization.NewtonsoftJson
{
    public static class JsonSerializerSettingsExtensions
    {
        public static JsonSerializerSettings ConfigureStringEnum(this JsonSerializerSettings settings)
        {
            settings.Converters.Add(new ToStringJsonConverter(typeof(StringEnum<>)));
            return settings;
        }
    }
}
