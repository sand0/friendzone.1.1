using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Friendzone.Web.Models
{
    public class EventDetailsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        
        public string City { get; set; }
        public string Description { get; set; }

        //public virtual UserProfile Owner { get; set; }
        public string OwnerUserId { get; set; }



        public virtual List<string> Categories { get; set; }
    }
}
