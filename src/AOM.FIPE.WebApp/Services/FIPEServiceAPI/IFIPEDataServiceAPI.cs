using AOM.FIPE.API.Response.FIPE;
using Refit;

namespace AOM.FIPE.WebApp.Services.FIPEServiceAPI
{
    public interface IFIPEDataServiceAPI
    {
        [Get("/api/fipe/{typeOfCar}")]
        Task<List<Brand>> Get([Authorize("Bearer")] string token, string typeOfCar);
    }
}
