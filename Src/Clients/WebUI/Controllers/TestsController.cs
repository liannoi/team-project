using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeamProject.Clients.Common.Models.Core.Returnable;
using TeamProject.Clients.Common.Tools;

namespace TeamProject.Clients.WebUI.Controllers
{
    public class TestsController : Controller
    {
        private readonly IApiTools _apiTools;

        public TestsController(IApiTools apiTools)
        {
            _apiTools = apiTools;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var model = (await _apiTools.FetchAsync<List<ActorReturnModel>>("https://localhost:5001/api/actors/getall"))
                .Take(10);

            return View(model);
        }
    }
}