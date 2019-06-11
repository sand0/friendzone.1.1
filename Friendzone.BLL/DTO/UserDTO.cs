using FriendZone.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Friendzone.BLL.DTO
{
    public class UserDTO
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public DateTime Birthday { get; set; }
        public Location Location { get; set; }
        
        public Photo Avatar { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }
    }
}
