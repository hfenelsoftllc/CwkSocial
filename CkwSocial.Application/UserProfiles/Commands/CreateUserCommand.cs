using CkwSocial.Application.Models;
using CwkSocial.Domain.Aggregates.UserProfileAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using CwkSocial.Domain.Aggregates.UserProfileAggregate;

namespace CkwSocial.Application.UserProfiles.Commands
{
    public class CreateUserCommand: IRequest<OperationResult<UserProfile>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Phone { get; set; }
       // public BirthInfo BirthInfo { get; set; }
        public string CurrentCity { get; set; }

        public DateTime DateOfBirth { get;  set; }
        public string PlaceOfBirth { get;  set; }
        public string County { get;  set; }
        public string City { get;  set; }
        public string State { get;  set; }
        public string Country { get;  set; }
    }
}
