using FluentValidation;

namespace TeamProject.Clients.Common.Models.Storage.Genres
{
    public class GenreBindingModelValidator : AbstractValidator<GenreBindingModel>
    {
        public GenreBindingModelValidator()
        {
            RuleFor(e => e.Title)
                .NotEmpty().WithMessage("Field can not be empty!");
        }
    }
}