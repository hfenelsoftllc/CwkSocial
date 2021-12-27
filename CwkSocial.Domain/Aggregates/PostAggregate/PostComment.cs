using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CwkSocial.Domain.Aggregates.PostAggregate
{
    public class PostComment
    {
        private PostComment()
        {

        }
        public Guid CommentId { get; private set; }
        public Guid PostId { get; private set; }
        public string Text { get; private set; }
        public Guid UserProfileId { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public DateTime LastModified { get; private set; }

        //Factories Strategy
        public static PostComment CreatePostComment(Guid postId, string text, Guid userProfileId)
        {
            // TO DO: add validation, error handling, error notification strategy

            return new PostComment 
            { 
                PostId = postId, 
                Text = text, 
                UserProfileId = userProfileId, 
                CreatedDate=DateTime.UtcNow, 
                LastModified=DateTime.UtcNow 
            };
        }

        //public method
        public void UpdateComment(string newText)
        {
            Text = newText;
            LastModified = DateTime.UtcNow;
        }
    }
}
