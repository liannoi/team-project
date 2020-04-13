using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace TeamProject.Clients.WebUI.Controllers
{
    public abstract class BaseController : Controller
    {
        protected void AddErrors(IEnumerable<string> errors)
        {
            foreach (var error in errors) ModelState.AddModelError("", error);
        }
    }
}