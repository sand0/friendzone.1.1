using System.Collections.Generic;

namespace Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        public virtual IEnumerable<UserProfileCategory> UserProfileCategory { get; set; }
        public virtual IEnumerable<EventCategory> EventCategory { get; set; }
    }
}
