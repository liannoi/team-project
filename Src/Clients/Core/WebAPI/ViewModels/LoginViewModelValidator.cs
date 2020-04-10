using FluentValidation;

namespace TeamProject.Clients.WebApi.ViewModels
{
    public class LoginViewModelValidator : AbstractValidator<LoginViewModel>
    {
        public LoginViewModelValidator()
        {
            RuleFor(e => e.Email)
                .NotNull()
                .NotEmpty();

            RuleFor(e => e.Password)
                .NotNull()
                .NotEmpty();
        }
    }
}