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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Brand>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(string tipoCar)
        {
            var response = await _fipeServices.GetBrand(tipoCar: tipoCar);

            return response == null ? NotFound() : Ok(response);
        }
    }
}
