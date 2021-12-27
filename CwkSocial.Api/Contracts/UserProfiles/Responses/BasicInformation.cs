﻿namespace CwkSocial.Api.Contracts.UserProfiles.Responses
{
    public record BasicInformation
    {
        public string FirstName { get;  set; }
        public string LastName { get;  set; }
        public string EmailAddress { get;  set; }
        public string Phone { get;  set; }
        public string CurrentCity { get;  set; }
    }
}
