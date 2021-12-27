using CkwSocial.Application.Models;
using CwkSocial.Domain.Aggregates.UserProfileAggregate;
using MediatR;
using System;


namespace CkwSocial.Application.UserProfiles.Commands
{
    public class UpdateUserProfileBasicInfo: IRequest<OperationResult<UserProfile>>
    {
        public Guid UserProfileId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Phone { get; set; }
        // public BirthInfo BirthInfo { get; set; }
        public string CurrentCity { get; set; }

        public DateTime DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }
        public string County { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}
