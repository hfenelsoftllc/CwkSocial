using CwkSocial.Domain.Exceptions;
using CwkSocial.Domain.Validators.UserProfileValidators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CwkSocial.Domain.Aggregates.UserProfileAggregate
{
    public class BirthInfo
    {
        private BirthInfo()
        {

        }
        public DateTime DateOfBirth { get; private set; }
        public string PlaceOfBirth { get; private set; }
        public string County { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }


        //Factories Strategy
        public static BirthInfo CreateBirthInfo(DateTime dateofbirth, string placeofbirth,string county,string city, string state,string country)
        {
            // add validation, error handling, error notification strategy

            var validator = new BirthInfoValidator();

            var objToValidate = new BirthInfo
            {
                DateOfBirth = dateofbirth,
                PlaceOfBirth = placeofbirth,
                County = county,
                City = city,
                State = state,
                Country = country
            };


            var validateResult = validator.Validate(objToValidate);

            if (validateResult.IsValid) return objToValidate;

            var exception = new UserProfileNotValidException("The birth Info is not valid");
            foreach (var error in validateResult.Errors)
            {
                exception.ValidationErrors.Add(error.ErrorMessage);
            }
            throw exception;

        }

    }
}
