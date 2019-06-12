using FriendZone.DAL.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace FriendZone.DAL.Entities
{
    public class Country : BaseEntity
    {
        public string Name { get; set; }

        public virtual List<City> Cities { get; set; }
    }
}
