using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Friendzone.Web.Models
{
    public class UserProfilePreviewModel
    {
        public string UserId { get; set; }

        public string UserName { get; set; }
        public string Email { get; set; }

        public string AvatarUrl { get; set; }

    }
}
