using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CwkSocial.Domain.Aggregates.UserProfileAggregate;
using FluentValidation;

namespace CwkSocial.Domain.Validators.UserProfileValidators
{
    internal class BirthInfoValidator: AbstractValidator<BirthInfo>
    {
        public BirthInfoValidator()
        {
            RuleFor(info => info.DateOfBirth)
                    .NotEmpty().WithMessage("Date of Birth shouldn't be null")
                    .InclusiveBetween(new DateTime(DateTime.Now.AddYears(-125).Ticks), new DateTime(DateTime.Now.AddYears(-18).Ticks))
                    .WithMessage("Age need to be between 18 and 125");
            RuleFor(info => info.PlaceOfBirth)
                .NotEmpty().WithMessage("Place of Birth shouldn't be null")
                .MinimumLength(5).WithMessage("Place name should be 5 character minimum");
        }
    }
}
