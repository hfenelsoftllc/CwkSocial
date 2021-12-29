﻿using CkwSocial.Application.Models;
using CkwSocial.Application.UserProfiles.Queries;
using CwkSocial.Dal;
using CwkSocial.Domain.Aggregates.UserProfileAggregate;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CkwSocial.Application.UserProfiles.QueryHandlers
{
    internal class GetUserProfileByIdQueryHandler : IRequestHandler<GetUserProfileById, OperationResult<UserProfile>>
    {
        private readonly DataContext _ctx;
        public GetUserProfileByIdQueryHandler(DataContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<OperationResult<UserProfile>> Handle(GetUserProfileById request, CancellationToken cancellationToken)
        {
            var result = new OperationResult<UserProfile>();

            var profile = await _ctx.UserProfiles.FirstOrDefaultAsync(up =>up.UserProfileId == request.UserProfileId);
           
            if (profile == null)
            {
                var error = new Error
                {
                    Code = Enums.ErrorCode.NotFound,
                    Message = $"No UserProfile found with ID {request.UserProfileId} does not exist.",
                };
                result.Errors.Add(error);
                return result;
            }
            result.Payload = profile;
            return result;
        }
    }
}
