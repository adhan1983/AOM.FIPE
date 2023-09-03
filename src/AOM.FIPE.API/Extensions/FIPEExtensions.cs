using AOM.FIPE.API.Services;
using Refit;

namespace AOM.FIPE.API.Extensions
{
    public static class FIPEExtensions
    {
        public static IServiceCollection AddingFIPEExtensions(this  IServiceCollection services,  IConfiguration configuration) 
        {
            var fipeSettings = configuration.GetSection("FIPEAPI");

            var baseUrl = fipeSettings.GetValue<string>("BaseUrl");

            services.AddRefitClient<IFIPEServices>().ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri(baseUrl);
            });

            return services;
        }
    }
}
