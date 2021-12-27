namespace CwkSocial.Api.Contracts.UserProfiles.Responses
{
    public class BirthInformation
    {
        public DateTime DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }
        public string County { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}
