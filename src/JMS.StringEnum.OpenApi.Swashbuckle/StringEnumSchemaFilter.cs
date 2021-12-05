using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace JMS.StringEnum.OpenApi.Swashbuckle
{
    /* Usage : 
    
    services.AddSwaggerGen(o =>
    {
        o.SchemaFilter<StringEnumSchemaFilter>();
    });
    
    */
    public class StringEnumSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.Type.BaseType?.IsGenericType == true)
            {
                if (context.Type.BaseType?.GetGenericTypeDefinition() == typeof(StringEnum<>))
                {
                    var allowableValues =
                        context.Type.GetField(
                                "AllValues", BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy)
                            .GetValue(null) as IEnumerable<string>;

                    schema.Enum = allowableValues.Select(x => new OpenApiString(x) as IOpenApiAny).ToList();
                    schema.Type = "string";
                }
            }
        }
    }
}
