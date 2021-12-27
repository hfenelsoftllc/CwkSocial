using CkwSocial.Application.UserProfiles.Commands;
using CwkSocial.Domain.Aggregates.UserProfileAggregate;
using MediatR;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CwkSocial.Dal;

namespace CkwSocial.Application.UserProfiles.CommandHandlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserProfile>
    {
        private readonly DataContext _ctx;
        //private readonly IMapper _mapper;

        public CreateUserCommandHandler(DataContext ctx)
        {
            _ctx = ctx;
           
        }
        public async Task<UserProfile> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var basicInfo = BasicInfo.CreateBasicInfo(request.FirstName, request.LastName, request.EmailAddress, request.Phone, request.CurrentCity);
            var birthInfo = BirthInfo.CreateBirthInfo(request.DateOfBirth, request.PlaceOfBirth, request.County, request.City, request.State, request.Country);

            var userProfile = UserProfile.CreateUserProfile(Guid.NewGuid().ToString(), basicInfo, birthInfo);
            _ctx.UserProfiles.Add(userProfile); 
            await _ctx.SaveChangesAsync();
            return userProfile;
        }
    }
}
