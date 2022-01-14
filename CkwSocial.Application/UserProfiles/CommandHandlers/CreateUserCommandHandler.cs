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
using CkwSocial.Application.Models;
using CwkSocial.Domain.Exceptions;
using CkwSocial.Application.Enums;

namespace CkwSocial.Application.UserProfiles.CommandHandlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, OperationResult<UserProfile>>
    {
        private readonly DataContext _ctx;
        //private readonly IMapper _mapper;

        public CreateUserCommandHandler(DataContext ctx)
        {
            _ctx = ctx;
           
        }
        public async Task<OperationResult<UserProfile>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<UserProfile>();

            try
            {

                var basicInfo = BasicInfo.CreateBasicInfo(request.FirstName, request.LastName, request.EmailAddress, request.Phone, request.CurrentCity);
                var birthInfo = BirthInfo.CreateBirthInfo(request.DateOfBirth, request.PlaceOfBirth, request.County, request.City, request.State, request.Country);

                var userProfile = UserProfile.CreateUserProfile(Guid.NewGuid().ToString(), basicInfo, birthInfo);
                _ctx.UserProfiles.Add(userProfile);
                await _ctx.SaveChangesAsync();
                result.Payload = userProfile;
                return result;
            }
            catch (UserProfileNotValidException ex)
            {
                result.isError = true;
                ex.ValidationErrors.ForEach(e =>
                {
                    var error = new Error {
                        Code = ErrorCode.ValidationError,
                        Message = $"{ex.Message}" 
                    };
                    result.Errors.Add(error);
                });
                return result;
            }
            catch(Exception e)
            {
                var error = new Error
                {
                    Code = ErrorCode.UnknownError,
                    Message = $"{e.Message}"
                };
                return result;
            }
        }
    }
}
