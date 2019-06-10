using FriendZone.DAL.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FriendZone.DAL.Entities
{
    public class Event : BaseEntity
    {
        [DataType(DataType.Date)]
        public DateTime DateFrom { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateTo { get; set; }

        public Location Location { get; set; }
        public Photo Photo { get; set; }
        public string Description { get; set; }

        public User Owner { get; set; }

        
    }
}
