using CwkSocial.Domain.Exceptions;
using CwkSocial.Domain.Validators.UserProfileValidators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CwkSocial.Domain.Aggregates.UserProfileAggregate
{
    public class BasicInfo
    {
        private BasicInfo()
        {

        }
        public string FirstName { get; private set; }   
        public string LastName { get; private set; }
        public string EmailAddress { get; private set; }
        public string Phone { get; private set; }
        public string CurrentCity { get; private set; }


        //Factories Strategy
        //public static BasicInfo TryCreateBasicInfo(string firstname, string lastname, string emailaddress, string phone, string currentcity, out BasicInfo basicInfo){}

        public static BasicInfo CreateBasicInfo(string firstname, string lastname, string emailaddress, string phone, string currentcity)
        {
            // TO DO: add validation, error handling, error notification strategy

            var validator = new BasicInfoValidator();

            var objToValidate = new BasicInfo
            {
                FirstName = firstname,
                LastName = lastname,
                EmailAddress = emailaddress,
                Phone = phone,
                CurrentCity = currentcity
            };

            var validateResult = validator.Validate(objToValidate);

            if (validateResult.IsValid) return objToValidate;
            var exception = new UserProfileNotValidException("The user profile is not valid");
            foreach(var error in validateResult.Errors)
            {
                exception.ValidationErrors.Add(error.ErrorMessage);
            }
            throw exception;
        }

    }
}
