﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CwkSocial.Domain.Aggregates.PostAggregate
{
    public class PostInteraction
    {
        private PostInteraction()
        {

        }
        public Guid InteractionId { get; private set; }
        public Guid PostId { get; private set; }
        public InteractionType InteractionType { get; private set; }


        //Factories Strategy
        public static PostInteraction CreatePostInteraction(Guid postId, InteractionType intType)
        {
            return new PostInteraction
            {
                PostId = postId,
                InteractionType = intType,
            };
        }


        //public method

    }
}
