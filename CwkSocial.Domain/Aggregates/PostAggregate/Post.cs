using CwkSocial.Domain.Aggregates.UserProfileAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CwkSocial.Domain.Aggregates.PostAggregate
{
    public class Post
    {
        private readonly List<PostComment> _comments = new();
        private readonly List<PostInteraction> _interactions = new();

        private Post()
        {
            //Comments = new List<PostComment>();
            //Interaction = new List<PostInteraction>();
        }

        public Guid PostId { get; private set; }
        public Guid UserProfileId { get; private set; }
        public UserProfile? UserProfile { get; private set; }
        public string? TextContent { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public DateTime LastModified { get; private set; }
        public IEnumerable<PostComment>? Comments { get { return _comments; } }
        public IEnumerable<PostInteraction>? Interactions { get { return _interactions; } }

        //Factories Strategy
        public static Post CreatePost(Guid userProfileId, string textContent)
        {
            return new Post
            {
                UserProfileId = userProfileId,
                TextContent = textContent,
                CreatedDate = DateTime.Now,
                LastModified = DateTime.Now,
            };
        }

        // public method
        public void UpdatePostText(string newText)
        {
            TextContent = newText;
            LastModified = DateTime.Now;
        }

        public void AddPostComment(PostComment newComment)
        {
            _comments.Add(newComment);
        }

        public void RemoveComment(PostComment postComment)
        {
            _comments.Remove(postComment);
        }

        public void AddInteraction(PostInteraction newInteraction)
        {
            _interactions.Add(newInteraction);
        }

       // public void UpdateInteraction(InteractionType interactionType) { InteractionType = interactionType; }

        public void RemoveInteraction(PostInteraction postInteraction)
        {
            _interactions.Remove(postInteraction);
        }

    }
}
