using AOM.FIPE.API.Response.FIPE;
using AOM.FIPE.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AOM.FIPE.API.Controllers
{
    [ApiController]
    [Route("api/fipe")]
    [Authorize]
    public class FIPEController : ControllerBase
    {
        private readonly IFIPEServices _fipeServices;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fIPEServices"></param>
        public FIPEController(IFIPEServices fIPEServices) => _fipeServices = fIPEServices;


        /// <summary>
        /// Get all brands in accorgind to type Of Vehicle: carros, motos ou caminhoes.
        /// </summary>
        /// <param name="tipoCar"></param>
        /// <returns></returns>
        [HttpGet("{tipoCar}")]
        public async Task<List<Brand>> Get(string tipoCar)
        {
            var brands = await _fipeServices.GetBrand(tipoCar: tipoCar);

            return brands;
        }
    }
}
