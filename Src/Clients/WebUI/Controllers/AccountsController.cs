using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TeamProject.Application.Common.Interfaces.Infrastructure;
using TeamProject.Clients.Common;
using TeamProject.Clients.Common.Models.Identity.Returnable;
using TeamProject.Clients.Common.Models.Identity.ViewModels;
using TeamProject.Clients.WebUI.Models;
using TeamProject.Domain.Entities;

namespace TeamProject.Clients.WebUI.Controllers
{
    public class AccountsController : BaseController
    {
        private readonly IApiTools _apiTools;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountsController(IApiTools apiTools, SignInManager<AppUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _apiTools = apiTools;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View(new RegisterViewModel {Roles = Roles()});
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

            if (result.Token != null)
            {
                HttpContext.Response.Cookies.Append(MvcClientDefaults.InCookiesJwtTokenName, result.Token);
                await _signInManager.PasswordSignInAsync(model.Email, model.Password, true, false);

                return RedirectToAction("Index", "Home");
            }

            AddErrors(result.Errors);
            model.Roles = Roles();

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

            if (result.Token != null)
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
        public async Task<IActionResult> SignOut()
        {
            HttpContext.Response.Cookies.Delete(MvcClientDefaults.InCookiesJwtTokenName);
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        private IEnumerable<SelectListItem> Roles()
        {
            return _roleManager.Roles.Select(x => new SelectListItem(x.Name, x.Id.ToString()));
        }
    }
}