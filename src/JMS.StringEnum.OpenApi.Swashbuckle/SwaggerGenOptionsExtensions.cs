using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace JMS.StringEnum.OpenApi.Swashbuckle
{
    public static class SwaggerGenOptionsExtensions
    {
        public static SwaggerGenOptions UseStringEnum(this SwaggerGenOptions options)
        {
            options.SchemaFilter<StringEnumSchemaFilter>();
            return options;
        }
    }
}
