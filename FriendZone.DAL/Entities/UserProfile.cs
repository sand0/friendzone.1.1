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

        public Photo Avatar { get; set; }
        public DateTime Birthday { get; set; }
        public Location Location { get; set; }
    }
}
