using Microsoft.OpenApi.Models;
using System.Reflection;

namespace AOM.FIPE.API.Extensions
{
    public static class SwaggerGenExtensions
    {
        public static IServiceCollection AddingSwaggerGenExtensions(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddSwaggerGen(swaggerGen =>
            {
                var setting = configuration.GetSection("SwaggerGen");
                
                string version = setting.GetValue<string>("Version");

                swaggerGen.SwaggerDoc(version, new OpenApiInfo
                {
                    Title = setting.GetValue<string>("Title"),
                    Version = version,
                    Description = setting.GetValue<string>("Description"),
                    Contact = new OpenApiContact
                    {
                        Name = setting.GetValue<string>("OpenApiContactName"),
                        Email = setting.GetValue<string>("OpenApiContactNameEmail"),
                        Url = new Uri(setting.GetValue<string>("OpenApiContactNameURL")),
                    },
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                swaggerGen.IncludeXmlComments(xmlPath);
            });

            return services;
        }
    }
}
