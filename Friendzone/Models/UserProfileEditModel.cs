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

        public DateTime Birthday { get; set; }
        public int CityId { get; set; }

    }
}
