using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TeamProject.Clients.WebApi.ViewModels;
using TeamProject.Domain.Entities;

namespace TeamProject.Clients.WebApi.Controllers
{
    public class AccountsController : BaseController
    {
        private readonly UserManager<AppUser> _userManager;

        public AccountsController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel registerModel)
        {
            if (!ModelState.IsValid) return BadRequest(new RegisterViewModelValidator().Validate(registerModel).Errors);

            await _userManager.CreateAsync(new AppUser {Email = registerModel.Email, UserName = registerModel.Email},
                registerModel.Password);

            return NoContent();
        }
    }
}