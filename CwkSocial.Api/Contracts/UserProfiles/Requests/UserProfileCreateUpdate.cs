using System.ComponentModel.DataAnnotations;

namespace CwkSocial.Api.Contracts.UserProfiles.Requests
{
    public record UserProfileCreateUpdate
    {
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string LastName { get; set; }
        [EmailAddress]
        [Required]
        public string EmailAddress { get; set; }

        public string Phone { get; set; }
        public string CurrentCity { get; set; }

        [Required]        
        public DateTime DateOfBirth { get; set; }

        [Required, MaxLength(150)]
        public string PlaceOfBirth { get; set; }

        public string County { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}
