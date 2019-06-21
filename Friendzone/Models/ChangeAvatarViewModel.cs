using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Friendzone.Web.Models
{
    public class ChangeAvatarViewModel
    {
        public int ProfileId { get; set; }
        public IFormFile Image { get; set; }
    }
}
