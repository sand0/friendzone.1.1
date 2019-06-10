using System;
using System.Collections.Generic;
using System.Text;

namespace FriendZone.DAL.Entities
{
    public class UserProfileCategory
    {
        public string UserProfileId { get; set; }
        public virtual UserProfile UserProfile { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        
    }
}
