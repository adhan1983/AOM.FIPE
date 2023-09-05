using AOM.FIPE.API.Response.FIPE;
using AOM.FIPE.WebApp.Models.Brand;
using AutoMapper;

namespace AOM.FIPE.WebApp.Extensions.Mappers
{
    public static class BrandMappersExtensions
    {
        public static IMapperConfigurationExpression AddingBrandMapper(this IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Brand, BrandViewModel>();

            return cfg;

        }
    }
}
