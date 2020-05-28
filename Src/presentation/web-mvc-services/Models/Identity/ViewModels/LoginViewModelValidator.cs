using FluentValidation;
using FluentValidation.Validators;

namespace TeamProject.Clients.Common.Models.Identity.ViewModels
{
    public class LoginViewModelValidator : AbstractValidator<LoginViewModel>
    {
        public LoginViewModelValidator()
        {
            RuleFor(e => e.Email)
                .NotNull()
                .NotEmpty()
                .EmailAddress(EmailValidationMode.AspNetCoreCompatible);

            RuleFor(e => e.Password)
                .NotNull()
                .NotEmpty();
        }
    }
}