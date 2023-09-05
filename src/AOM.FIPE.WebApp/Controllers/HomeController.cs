using AOM.FIPE.API.Response.FIPE;
using AOM.FIPE.WebApp.Models;
using AOM.FIPE.WebApp.Models.Brand;
using Firebase.Auth;
using Microsoft.AspNetCore.Mvc;
using Refit;
using System.Diagnostics;
using System.Net;

namespace AOM.FIPE.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            
            var token = HttpContext.Session.GetString("_UserToken");

            if (token != null)
            {
                IDataService dataService = RestService.For<IDataService>("https://localhost:7088/");
                
                var brands = await dataService.Get(token, "carros");

                var response = new BrandResponseViewModel() 
                {
                    Total = brands.Count,
                    
                    Brands = brands.Select(b => new BrandViewModel() { Nome = b.Nome, Codigo = b.Codigo  }).ToList()                    
                };

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