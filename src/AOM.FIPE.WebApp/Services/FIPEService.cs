using AOM.FIPE.API.Response.FIPE;
using AOM.FIPE.WebApp.Models.Brand;
using AOM.FIPE.WebApp.Services.FIPEServiceAPI;
using AutoMapper;
using Refit;

namespace AOM.FIPE.WebApp.Services
{
    public class FIPEService : IFIPEService
    {
        IFIPEDataServiceAPI service;
        private readonly IMapper _mapper;
        public FIPEService(IMapper mapper) 
        {
            service = RestService.For<IFIPEDataServiceAPI>("https://localhost:7088/");
            _mapper = mapper;
        }

        public async Task<BrandResponseViewModel> GetBrandAsync(string token, string typeOfCar)
        {
            List<Brand> brands = await service.Get(token, typeOfCar);
            
            var response = new BrandResponseViewModel()
            {
                Total = brands.Count,

                Brands = _mapper.Map<List<BrandViewModel>>(brands)
            };

            return response;
        }

    }
}
