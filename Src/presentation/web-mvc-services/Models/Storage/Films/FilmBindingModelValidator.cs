using FluentValidation;

namespace TeamProject.Clients.Common.Models.Storage.Films
{
    public class FilmBindingModelValidator : AbstractValidator<FilmBindingModel>
    {
        public FilmBindingModelValidator()
        {
            RuleFor(e => e.Description)
                .MaximumLength(4000);

            RuleFor(e => e.PublishYear)
                .NotEmpty();

            RuleFor(e => e.Title)
                .NotNull().WithMessage("Movie title cannot be empty.")
                .NotEmpty().WithMessage("Movie title cannot be empty.")
                .MaximumLength(128);
        }
    }
}