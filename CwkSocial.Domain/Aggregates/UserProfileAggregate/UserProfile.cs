﻿

namespace CwkSocial.Domain.Aggregates.UserProfileAggregate
{
    public class UserProfile
    {
        private UserProfile()
        {

        }
        public Guid UserProfileId { get; private set; }
        public string? IdentityId { get; private set; }
        public BasicInfo? BasicInfo { get; private set; }
        public BirthInfo? BirthInfo { get; private set; }  
        public DateTime DateCreated { get; private set; }
        public DateTime LastModified { get; private set; }

        //Factories Strategy
        public static UserProfile CreateUserProfile(string identityId, BasicInfo basicInfo, BirthInfo birthInfo) {
            // TO DO: add validation, error handling, error notification strategy

            return new UserProfile()
            {
                IdentityId = identityId,
                BasicInfo = basicInfo,
                BirthInfo = birthInfo,
                DateCreated = DateTime.UtcNow,
                LastModified = DateTime.UtcNow
            };
        }

        public void UpdateBasicInfo(BasicInfo newInfo)
        { 
            BasicInfo = newInfo;
            LastModified = DateTime.UtcNow;
        }

        public void UpdateBirthInfo(BirthInfo newInfo) 
        {
            BirthInfo = newInfo;
            LastModified= DateTime.UtcNow;
        }

    }
}
