using System;
using FluentValidation;

namespace TeamProject.Application.Storage.Actors
{
    public class ActorLookupDtoValidator : AbstractValidator<ActorLookupDto>
    {
        public ActorLookupDtoValidator()
        {
            RuleFor(e => e.FirstName)
                .NotNull();
            RuleFor(e => e.LastName)
                .NotNull();
            RuleFor(e => e.Birthday)
                .NotNull()
                .GreaterThanOrEqualTo(new DateTime(1900, 01, 01)).WithMessage("Date of birth must be grater than 01.01.1900");
        }
    }
}