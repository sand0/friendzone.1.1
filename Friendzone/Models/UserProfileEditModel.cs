using Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Friendzone.Web.Models
{
    public class UserProfileEditModel
    {
        public int Id { get; set; }

        public string Email { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }

        public IFormFile Avatar { get; set; }
        public DateTime Birthday { get; set; }

        public City City { get; set; }


    }
}
