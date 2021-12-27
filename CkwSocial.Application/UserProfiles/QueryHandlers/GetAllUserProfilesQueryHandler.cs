﻿using CkwSocial.Application.UserProfiles.Queries;
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
    internal class GetAllUserProfilesQueryHandler : IRequestHandler<GetAllUserProfiles, IEnumerable<UserProfile>>
    {
        private readonly DataContext _ctx;

        public GetAllUserProfilesQueryHandler(DataContext ctx)
        {
            _ctx = ctx; 
        }

        public async Task<IEnumerable<UserProfile>> Handle(GetAllUserProfiles request, CancellationToken cancellationToken)
        {
            return await _ctx.UserProfiles.ToListAsync();
        }


    }
}
