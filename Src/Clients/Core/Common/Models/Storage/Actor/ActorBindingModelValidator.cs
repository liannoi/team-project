using System;
using FluentValidation;

namespace TeamProject.Clients.Common.Models.Storage.Actor
{
    public class ActorBindingModelValidator : AbstractValidator<ActorBindingModel>
    {
        public ActorBindingModelValidator()
        {
            RuleFor(e => e.FirstName)
                .NotNull().WithMessage("Параметр FirstName не должно быть пустым или null").MinimumLength(3)
                .WithMessage("FirstName must be longer than 2");
            RuleFor(e => e.LastName)
                .NotNull().WithMessage("Параметр LasrtName не должно быть пустым или null");
            RuleFor(e => e.Birthday)
                .NotNull()
                .GreaterThanOrEqualTo(new DateTime(1900, 01, 01))
                .WithMessage("Date of birth must be grater than 01.01.1900");
        }
    }
}