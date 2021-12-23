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
            // TO DO: add validation, error handling, error notification strategy


            return new BirthInfo
            {
                DateOfBirth = dateofbirth,
                PlaceOfBirth = placeofbirth,
                County = county,
                City = city,
                State = state,
                Country = country
            };
        }

    }
}
