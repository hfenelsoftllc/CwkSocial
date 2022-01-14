using CkwSocial.Application.Enums;
using CkwSocial.Application.Models;
using CkwSocial.Application.UserProfiles.Commands;
using CwkSocial.Dal;
using CwkSocial.Domain.Aggregates.UserProfileAggregate;
using CwkSocial.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CkwSocial.Application.UserProfiles.CommandHandlers
{
    internal class UpdateUserProfilBasicInfoHandler: IRequestHandler<UpdateUserProfileBasicInfo, OperationResult<UserProfile>>
    {
        private readonly DataContext _ctx;
        public UpdateUserProfilBasicInfoHandler(DataContext ctx)
        {
            _ctx = ctx; 
        }

        public async Task<OperationResult<UserProfile>> Handle(UpdateUserProfileBasicInfo request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<UserProfile>();

            try
            {
            var userProfile = await _ctx.UserProfiles
                                        .FirstOrDefaultAsync(up => up.UserProfileId == request.UserProfileId);
               
                if (userProfile == null)
                {
                    result.isError = true;
                    var error = new Error
                    {
                        Code = Enums.ErrorCode.NotFound,
                        Message = $"No UserProfile found with ID {request.UserProfileId} is not valid.",
                    };
                    result.Errors.Add(error);
                    return result;
                }

                var basicInfo = BasicInfo.CreateBasicInfo(request.FirstName, request.LastName, request.EmailAddress, request.Phone, request.CurrentCity);
                var birthInfo = BirthInfo.CreateBirthInfo(request.DateOfBirth, request.PlaceOfBirth, request.County, request.City, request.State, request.Country);
                
                userProfile.UpdateBasicInfo(basicInfo);
                userProfile.UpdateBirthInfo(birthInfo);

                _ctx.UserProfiles.Update(userProfile);

                await _ctx.SaveChangesAsync();

                result.Payload = userProfile;
                return result;

            }
            catch (UserProfileNotValidException ex)
            {
                result.isError = true;
                ex.ValidationErrors.ForEach(e =>
                {
                    var error = new Error
                    {
                        Code = ErrorCode.ValidationError,
                        Message = $"{ex.Message}"
                    };
                    result.Errors.Add(error);
                });
                return result;
            }
            catch (Exception e)
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
