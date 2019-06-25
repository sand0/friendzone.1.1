using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Friendzone.Core.DTO
{
    public class EventDTO
    {
        public int Id { get; set; }
        
        public string Title { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

        public int CityId { get; set; }

        public List<int> CategoriyIds { get; set; }

        public int OwnerId { get; set; }

        public string Description { get; set; }
    }
}
