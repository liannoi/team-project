using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace TeamProject.Clients.WebUI.Controllers.Common
{
    public abstract class BaseController : Controller
    {
        public string JwtToken => HttpContext.Request.Cookies[MvcClientDefaults.InCookiesJwtTokenName];

        protected void AddErrors(IEnumerable<string> errors)
        {
            foreach (var error in errors) ModelState.AddModelError("", error);
        }
    }
}