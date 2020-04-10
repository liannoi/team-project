using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TeamProject.Application.Common.Interfaces;
using TeamProject.Clients.WebApi.ViewModels;
using TeamProject.Domain.Entities;

namespace TeamProject.Clients.WebApi.Controllers
{
    public class AccountsController : BaseController
    {
        private readonly IIdentityService _identityService;
        private readonly UserManager<AppUser> _userManager;

        public AccountsController(UserManager<AppUser> userManager, IIdentityService identityService)
        {
            _userManager = userManager;
            _identityService = identityService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel registerModel)
        {
            if (!ModelState.IsValid) return BadRequest(new RegisterViewModelValidator().Validate(registerModel).Errors);

            var user = new AppUser {Email = registerModel.Email, UserName = registerModel.Email};
            var result = await _userManager.CreateAsync(user, registerModel.Password);

            if (result.Succeeded) return Ok(_identityService.CreateJsonWebToken(user));

            AddErrors(result);

            return BadRequest(ModelState);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login([FromBody] LoginViewModel loginModel)
        {
            if (!ModelState.IsValid) return BadRequest(new LoginViewModelValidator().Validate(loginModel).Errors);

            var user = await _userManager.FindByEmailAsync(loginModel.Email);

            if (await _userManager.CheckPasswordAsync(user, loginModel.Password))
                return Ok(_identityService.CreateJsonWebToken(user));

            ModelState.AddModelError("", "Invalid username or password");

            return BadRequest(ModelState);
        }

#if Debug
        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public ActionResult<string> Welcome()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var claims = identity.Claims.ToList();
            var userName = claims[0].Value;
            return $"Welcome To: {userName}";
        }
#endif
    }
}