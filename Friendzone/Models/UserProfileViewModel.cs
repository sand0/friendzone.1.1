using Entities;

namespace Friendzone.Web.Models
{
    public class UserProfileViewModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }

        public string AvatarUrl { get; set; }
        public int Age { get; set; }
        public City City { get; set; }
        //public List<Event> Events { get; set; }
    }
}
