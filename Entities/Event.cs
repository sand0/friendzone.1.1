using System;
using System.Collections.Generic;

namespace Entities
{
    public class Event : BaseEntity
    {
        public string Title { get; set; }

        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }

        public int CityId { get; set; }
        public virtual City City { get; set; }

        public virtual Photo Photo { get; set; }
        public string Description { get; set; }

        public int OwnerId { get; set; }
        public virtual UserProfile Owner { get; set; }

        public virtual List<EventCategory> EventCategory { get; set; }
    }
}
