using AOM.FIPE.WebApp.Models.Brand;

namespace AOM.FIPE.WebApp.Services
{
    public interface IFIPEService
    {
        public Task<BrandResponseViewModel> GetBrandAsync(string token, string typeOfCar);
    }
}
