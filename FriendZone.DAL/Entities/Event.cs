using FriendZone.DAL.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FriendZone.DAL.Entities
{
    public class Event : BaseEntity
    {

        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }

        public virtual Location Location { get; set; }
        public virtual Photo Photo { get; set; }
        public string Description { get; set; }

        public string OwnerId { get; set; }
        public virtual UserProfile Owner { get; set; }

        public virtual IEnumerable<EventCategory> EventCategory { get; set; }
    }
}
