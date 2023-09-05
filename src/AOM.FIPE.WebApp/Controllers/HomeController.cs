using AOM.FIPE.API.Response.FIPE;
using AOM.FIPE.WebApp.Models;
using AOM.FIPE.WebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Refit;
using System.Diagnostics;

namespace AOM.FIPE.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFIPEService _fIPEService;
        public HomeController(IFIPEService fIPEService) => _fIPEService = fIPEService;
        public async Task<IActionResult> Index()
        {
            var token = HttpContext.Session.GetString("_UserToken");

            if (token != null)
            {
                var response = await _fIPEService.GetBrandAsync(token, "carros");
                
                return View(response);
            }
            else
            {
                return RedirectToAction("SignIn", "Account");
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    public interface IDataService
    {
        [Get("/api/fipe/{typeOfCar}")]
        Task<List<Brand>> Get([Authorize("Bearer")] string token, string typeOfCar);
    }
}