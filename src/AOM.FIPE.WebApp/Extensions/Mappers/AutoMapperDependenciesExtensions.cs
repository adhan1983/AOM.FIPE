using AutoMapper;

namespace AOM.FIPE.WebApp.Extensions.Mappers
{
    public static class AutoMapperDependenciesExtensions
    {
        public static IServiceCollection AddingAutoMapper(this IServiceCollection services)
        {

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddingBrandMapper();

            });

            IMapper mapper = config.CreateMapper();

            services.AddSingleton(mapper);

            return services;
        }
    }
}
