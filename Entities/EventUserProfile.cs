using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class EventUserProfile
    {
        public string UserProfileId { get; set; }
        public virtual UserProfile UserProfile { get; set; }

        public int EventId { get; set; }
        public virtual Event Event { get; set; }
    }
}
