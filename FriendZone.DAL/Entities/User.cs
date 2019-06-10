using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace FriendZone.DAL.Entities
{
    public class User : IdentityUser
    {
        public int ProfileId { get; set; }
        public UserProfile Profile { get; set; }
    }
}
