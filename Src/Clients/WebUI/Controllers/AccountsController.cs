using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TeamProject.Application.Common.Interfaces.Infrastructure;
using TeamProject.Clients.Common;
using TeamProject.Clients.Common.Models.Identity.Returnable;
using TeamProject.Clients.Common.Models.Identity.ViewModels;
using TeamProject.Domain.Entities.Identity;

namespace TeamProject.Clients.WebUI.Controllers
{
    public class AccountsController : BaseController
    {
        private readonly IApiTools _apiTools;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountsController(IApiTools apiTools, SignInManager<AppUser> signInManager)
        {
            _apiTools = apiTools;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp([FromForm] RegisterViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var result =
                await _apiTools.PostAsync<JwtTokenReturnModel>(CommonClientsDefaults.WebApiAccountsControllerRegister,
                    model);

            #region Token received (response from service)

            if (!string.IsNullOrEmpty(result.Token))
            {
                HttpContext.Response.Cookies.Append(MvcClientDefaults.InCookiesJwtTokenName, result.Token);
                //_signInManager.PasswordSignInAsync(model.Email,)
                return RedirectToAction("Index", "Home");
            }

            AddErrors(result.Errors);
            return View(model);

            #endregion
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn([FromForm] LoginViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var result =
                await _apiTools.PostAsync<JwtTokenReturnModel>(CommonClientsDefaults.WebApiAccountsControllerLogin,
                    model);

            #region Token received (response from service)

            if (!string.IsNullOrEmpty(result.Token))
            {
                HttpContext.Response.Cookies.Append(MvcClientDefaults.InCookiesJwtTokenName, result.Token);
                await _signInManager.PasswordSignInAsync(model.Email, model.Password, true, false);
                return RedirectToAction("Index", "Home");
            }

            AddErrors(result.Errors);
            return View(model);

            #endregion
        }

        [HttpPost]
        public IActionResult SignOut()
        {
            HttpContext.Response.Cookies.Delete(MvcClientDefaults.InCookiesJwtTokenName);
            return RedirectToAction("Index", "Home");
        }
    }
}