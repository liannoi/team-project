using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TeamProject.Application.Common.Interfaces.Infrastructure;
using TeamProject.Clients.WebApi.Models.Identity.Returnable;
using TeamProject.Clients.WebApi.Models.Identity.ViewModels;
using TeamProject.Domain.Entities;

namespace TeamProject.Clients.WebApi.Controllers
{
    public class AccountsController : BaseController
    {
        private readonly IIdentityService _identityService;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountsController(UserManager<AppUser> userManager, IIdentityService identityService,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _identityService = identityService;
            _roleManager = roleManager;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<JwtTokenReturnModel>> Register([FromBody] RegisterViewModel registerModel)
        {
            if (!ModelState.IsValid) return BadRequest(new RegisterViewModelValidator().Validate(registerModel).Errors);

            var user = new AppUser {Email = registerModel.Email, UserName = registerModel.Email};
            var result = await _userManager.CreateAsync(user, registerModel.Password);

            if (!result.Succeeded)
                return BadRequest(new JwtTokenReturnModel {Errors = result.Errors.Select(error => error.Description)});

            await _userManager.AddToRoleAsync(await _userManager.FindByEmailAsync(registerModel.Email),
                (await _roleManager.FindByIdAsync(registerModel.Role)).Name);

            return Ok(new JwtTokenReturnModel {Token = _identityService.CreateJsonWebToken(user)});
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<JwtTokenReturnModel>> Login([FromBody] LoginViewModel loginModel)
        {
            if (!ModelState.IsValid) return BadRequest(new LoginViewModelValidator().Validate(loginModel).Errors);

            var user = await _userManager.FindByEmailAsync(loginModel.Email);
            var succeeded = await _userManager.CheckPasswordAsync(user, loginModel.Password);
            if (succeeded)
                return Ok(new JwtTokenReturnModel
                    {Token = _identityService.CreateJsonWebToken(user)});

            return BadRequest(new JwtTokenReturnModel {Errors = new List<string> {"Invalid username or password."}});
        }

        // TODO: Remove.
#if Debug
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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