using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TeamProject.Clients.WebUI.Models
{
    public class RegisterViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public IEnumerable<SelectListItem> Roles { get; set; }
        public string Role { get; set; }
    }
}