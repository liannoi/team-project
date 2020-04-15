using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeamProject.Application.Common.Interfaces.Infrastructure;
using TeamProject.Clients.Common;
using TeamProject.Clients.Common.Models.Storage.Films;
using TeamProject.Clients.WebUI.Controllers.Common;

namespace TeamProject.Clients.WebUI.Controllers.Storage
{
    [Authorize(Roles = "Administrator")]
    public class FilmsWebUiController : BaseController
    {
        private readonly IApiTools _apiTools;
        private readonly IAuthorizeApiTools _authorizeApiTools;

        public FilmsWebUiController(IApiTools apiTools, IAuthorizeApiTools authorizeApiTools)
        {
            _apiTools = apiTools;
            _authorizeApiTools = authorizeApiTools;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<FilmBindingModel> fetch;

            try
            {
                fetch = await _authorizeApiTools.FetchAsync<List<FilmBindingModel>>(CommonClientsDefaults.WebApiFilmsControllerGetAll, JwtToken);
            }
            catch (AuthenticationException)
            {
                return RedirectToAction("Login", "Account");
            }

            var model = fetch.TakeLast(10);

            return View(model);
        }
    }
}