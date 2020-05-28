using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace TeamProject.Clients.Common.Models.Storage.Genres
{
    public class GenreBindingModelValidator: AbstractValidator<GenreBindingModel>
    {
        public GenreBindingModelValidator()
        {
            RuleFor(e => e.Title)
                .NotEmpty().WithMessage("This field can not be empty");
        }
    }
}
