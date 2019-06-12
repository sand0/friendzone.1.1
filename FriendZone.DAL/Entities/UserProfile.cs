using FriendZone.DAL.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace FriendZone.DAL.Entities
{
    public class UserProfile : BaseEntity
    {
        public string UserId { get; set; }
        public virtual User User { get; set; }

        public virtual Photo Avatar { get; set; }
        public DateTime Birthday { get; set; }
        public virtual City City { get; set; }

        public virtual IEnumerable<UserProfileCategory> UserProfileCategory { get; set; }
    }
}
