using System;
using System.Collections.Generic;
using System.Text;

namespace Friendzone.BLL.DTO
{
    public class ProfileDTO
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }

        public string AvatarUrl { get; set; }
        public DateTime Birthday { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
