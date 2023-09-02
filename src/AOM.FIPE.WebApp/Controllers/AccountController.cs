using AOM.FIPE.FirebaseAuthentication.SDK.Http;
using AOM.FIPE.WebApp.Models;
using Firebase.Auth;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AOM.FIPE.WebApp.Controllers
{
    public class AccountController : Controller
    {
        
        private readonly IFirebaseRegisterService _firebaseRegisterService;
        private readonly IFirebaseLoginService _firebaseLoginService;
        private readonly IFirebaseRefreshService _firebaseRefreshService;

        public AccountController(IFirebaseRegisterService firebaseRegisterService, IFirebaseLoginService firebaseLoginService, IFirebaseRefreshService firebaseRefreshService) 
        { 
            _firebaseRegisterService = firebaseRegisterService;
            _firebaseLoginService = firebaseLoginService;
            _firebaseRefreshService = firebaseRefreshService;
        }

        #region SignIn

        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(LoginModel loginModel)
        {
            try
            {
                LoginResponse loginResponse = await _firebaseLoginService.Login(new LoginRequest
                {
                    Email = loginModel.Email,
                    Password = loginModel.Password
                });

                HttpContext.Session.SetString("_UserToken", loginResponse.IdToken);

                return RedirectToAction("Index", "Home");

            }
            catch (FirebaseAuthException ex)
            {
                var firebaseEx = JsonConvert.DeserializeObject<FirebaseError>(ex.ResponseData);
                ModelState.AddModelError(String.Empty, firebaseEx.error.message);
                return View(loginModel);
            }

            
        }

        #endregion

        #region Registration
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(LoginModel loginModel)
        {
            try
            {
                RegisterResponse registerResponse = await _firebaseRegisterService.Register(new RegisterRequest
                {
                    Email = loginModel.Email,
                    Password = loginModel.Password                    
                });

                if (registerResponse.IdToken != null)
                {

                    await _firebaseLoginService.Login(new LoginRequest
                    {
                        Email = loginModel.Email,
                        Password = loginModel.Password
                    });

                    HttpContext.Session.SetString("_UserToken", registerResponse.IdToken);

                    return RedirectToAction("Index", "Home");
                }
            }
            catch (FirebaseAuthException ex)
            {
                var firebaseEx = JsonConvert.DeserializeObject<FirebaseError>(ex.ResponseData);
                ModelState.AddModelError(String.Empty, firebaseEx.error.message);
                return View(loginModel);
            }

            return View();

        }

        #endregion

        #region LogOut
        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("_UserToken");
            return RedirectToAction("SignIn", "Account");
        }

        #endregion

    }
}
