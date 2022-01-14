using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CwkSocial.Domain.Aggregates.UserProfileAggregate;
using FluentValidation;
using FluentValidation.Validators;

namespace CwkSocial.Domain.Validators.UserProfileValidators
{
    internal class BasicInfoValidator: AbstractValidator<BasicInfo>
    {
        public BasicInfoValidator()
        {
            RuleFor(info => info.FirstName)
                   .NotNull().WithMessage("FirstName is required. It is currently null")
                   .MinimumLength(3).WithMessage("Firstname must be at least 3 character long")
                   .MaximumLength(50).WithMessage("Firstname must be contain 50 character long");

            RuleFor(info => info.LastName)
                   .NotNull().WithMessage("Lastname is required. It is currently null")
                   .MinimumLength(3).WithMessage("Lastname must be at least 3 character long")
                   .MaximumLength(50).WithMessage("Lastname must be contain 50 character long");

            RuleFor(info => info.EmailAddress)
                   .NotNull().WithMessage("Email Address is required.")
                   .EmailAddress(EmailValidationMode.AspNetCoreCompatible).WithMessage("Provide string is not a correct email address format");
           
                   
        }
    }
}
