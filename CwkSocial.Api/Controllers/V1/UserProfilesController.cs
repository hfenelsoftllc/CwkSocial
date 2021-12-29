using AutoMapper;
using CkwSocial.Application.UserProfiles.Commands;
using CkwSocial.Application.UserProfiles.Queries;
using CwkSocial.Api.Contracts.UserProfiles.Requests;
using CwkSocial.Api.Contracts.UserProfiles.Responses;
using CkwSocial.Application.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CwkSocial.Api.Controllers.V1
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route(ApiRoutes.BaseRoute)]
    public class UserProfilesController: Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public UserProfilesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
           
        [HttpGet]
        public async Task<IActionResult> GetAllProfiles()
        {
            var query = new GetAllUserProfiles();
            var response = await _mediator.Send(query);
            var profile = _mapper.Map<List<UserProfileResponse>>(response.Payload);

            return Ok(profile);
        }       


        [Route(ApiRoutes.UserProfiles.IdRoute)]
        [HttpGet]
        public async Task<IActionResult> GetUserProfileById(string id)
        {
            var query = new GetUserProfileById
            {
                UserProfileId = Guid.Parse(id),
            };
            var response = await _mediator.Send(query);

            var userProfile = _mapper.Map<UserProfileResponse>(response.Payload);
            return Ok(userProfile);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserProfile([FromBody] UserProfileCreateUpdate profile)
        {
            var command = _mapper.Map<CreateUserCommand>(profile);
            var response = await _mediator.Send(command);  
            var userProfile = _mapper.Map<UserProfileResponse>(response.Payload);
            //return CreatedAtActionResult(nameof(GetUserProfileById), new { id = response.UserProfileId }, userProfile); //
            return CreatedAtAction(nameof(GetUserProfileById), 
                            new { id = response.Payload.UserProfileId }, 
                            userProfile);
        }


        [HttpPatch]
        [Route(ApiRoutes.UserProfiles.IdRoute)]
        public async Task<IActionResult> UpdateUserProfile(string id, UserProfileCreateUpdate updatedProfile)
        {
            var command = _mapper.Map<UpdateUserProfileBasicInfo>(updatedProfile);
            command.UserProfileId = Guid.Parse(id);
            var response = await _mediator.Send(command);

            if (response.isError)
            {
                if (response.Errors.Any(e =>e.Code == ErrorCode.NotFound))
                {
                    var error = response.Errors.FirstOrDefault(e =>e.Code == ErrorCode.NotFound);
                }
            }
            return NoContent();
        }


        [HttpDelete]
        [Route(ApiRoutes.UserProfiles.IdRoute)]
        public async Task<IActionResult> DeleteUserProfile(string id)
        {
            var command = new DeleteUserProfile { UserProfileId = Guid.Parse(id) };
            var response = await _mediator.Send(command);

            return NoContent();
        }
    }
}
