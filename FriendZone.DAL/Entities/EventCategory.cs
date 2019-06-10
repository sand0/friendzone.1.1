using System;
using System.Collections.Generic;
using System.Text;

namespace FriendZone.DAL.Entities
{
    public class EventCategory
    {
        public int EventId { get; set; }
        public virtual Event Event { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
