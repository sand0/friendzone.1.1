using Entities;
using System;

namespace Friendzone.Core.DTO
{
    public class UserDTO
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public DateTime Birthday { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        
        public Photo Avatar { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }
    }
}
