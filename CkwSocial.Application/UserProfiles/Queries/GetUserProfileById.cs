using CwkSocial.Domain.Aggregates.UserProfileAggregate;
using MediatR;
using System;


namespace CkwSocial.Application.UserProfiles.Queries
{
    public class GetUserProfileById : IRequest<UserProfile>
    {
        public Guid UserProfileId { get; set; }
    }
}
