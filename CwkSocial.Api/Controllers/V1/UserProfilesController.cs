using AutoMapper;
using CkwSocial.Application.UserProfiles.Commands;
using CkwSocial.Application.UserProfiles.Queries;
using CwkSocial.Api.Contracts.UserProfiles.Requests;
using CwkSocial.Api.Contracts.UserProfiles.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CwkSocial.Api.Controllers.V1
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route(ApiRoutes.BaseRoute)]
    public class UserProfilesController: BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<UserProfilesController> _logger;
        public UserProfilesController(IMediator mediator, IMapper mapper, ILogger<UserProfilesController> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }
           
        [HttpGet]
        public async Task<IActionResult> GetAllProfiles()
        {
            var query = new GetAllUserProfiles();
            var response = await _mediator.Send(query);
            var profile = _mapper.Map<List<UserProfileResponse>>(response.Payload);
            
            //_logger.LogInformation("Getting user profile from url:",profile);

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
            if (response.isError)
                return HandleErrorResponse(response.Errors);

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
                        
            return response.isError ? HandleErrorResponse(response.Errors) : NoContent();
        }


        [HttpDelete]
        [Route(ApiRoutes.UserProfiles.IdRoute)]
        public async Task<IActionResult> DeleteUserProfile(string id)
        {
            var command = new DeleteUserProfile { UserProfileId = Guid.Parse(id) };
            var response = await _mediator.Send(command);

            return response.isError ? HandleErrorResponse(response.Errors) : NoContent();

        }
    }
}
