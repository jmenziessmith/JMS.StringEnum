using JMS.StringEnum.OpenApi.Swashbuckle;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Example.StringEnum.WebApi
{
    public static class SwaggerConfig
    {
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(o =>
            {
                o.UseStringEnum(); // o.SchemaFilter<StringEnumSchemaFilter>();
            });
            // services.AddSwaggerGenNewtonsoftSupport();
        }

        public static void AddSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
               
            });
        }
    }
}
