﻿namespace TeamProject.Clients.WebApi.Models.Identity.ViewModels
{
    public class RegisterViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public string Role { get; set; }
    }
}