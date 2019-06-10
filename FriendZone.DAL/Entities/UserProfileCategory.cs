using System;
using System.Collections.Generic;
using System.Text;

namespace FriendZone.DAL.Entities
{
    public class UserProfileProfile
    {
        public int UserProfileId { get; set; }
        public UserProfile UserProfile { get; set; }

        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
