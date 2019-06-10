using FriendZone.DAL.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace FriendZone.DAL.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        public virtual IEnumerable<UserProfileCategory> UserProfileCategory { get; set; }
        public virtual IEnumerable<EventCategory> EventCategory { get; set; }
    }
}
