using FluentValidation;
using FluentValidation.Validators;

namespace TeamProject.Clients.WebApi.Models.Identity.ViewModels
{
    public class RegisterViewModelValidator : AbstractValidator<RegisterViewModel>
    {
        public RegisterViewModelValidator()
        {
            RuleFor(e => e.Email)
                .NotNull()
                .NotEmpty()
                .EmailAddress(EmailValidationMode.AspNetCoreCompatible);

            RuleFor(e => e.Password)
                .NotNull()
                .NotEmpty()
                .MaximumLength(100)
                .MinimumLength(6);

            RuleFor(e => e.ConfirmPassword)
                .Equal(e => e.Password).WithMessage("Passwords entered must match.");
        }
    }
}