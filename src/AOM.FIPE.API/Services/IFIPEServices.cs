using AOM.FIPE.API.Response.FIPE;
using Microsoft.AspNetCore.Mvc;
using Refit;

namespace AOM.FIPE.API.Services
{
    [Headers("Content-Type: application/json")]
    public interface IFIPEServices
    {
        [Get("/v1/{tipoCar}/marcas")]
        Task<List<Brand>> GetBrand([FromQuery] string tipoCar);
    }
}
