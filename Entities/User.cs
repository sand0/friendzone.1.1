using Microsoft.AspNetCore.Identity;

namespace Entities
{
    public class User : IdentityUser
    {
        public int ProfileId { get; set; }
        public virtual UserProfile Profile { get; set; }
    }
}
