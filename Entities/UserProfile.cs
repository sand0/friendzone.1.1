﻿using System;
using System.Collections.Generic;

namespace Entities
{
    public class UserProfile : BaseEntity
    {
        public string UserId { get; set; }
        public virtual User User { get; set; }

        public virtual Photo Avatar { get; set; }
        public DateTime Birthday { get; set; }
        public virtual City City { get; set; }

        public virtual List<UserProfileCategory> UserProfileCategory { get; set; }

        public virtual IEnumerable<Event> MyEvents { get; set; }
        public virtual IEnumerable<EventUserProfile> ChosenEvents { get; set; }
    }
}
