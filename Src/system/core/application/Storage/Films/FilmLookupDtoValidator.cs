using FluentValidation;

namespace TeamProject.Application.Storage.Films
{
    public class FilmLookupDtoValidator : AbstractValidator<FilmLookupDto>
    {
        public FilmLookupDtoValidator()
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