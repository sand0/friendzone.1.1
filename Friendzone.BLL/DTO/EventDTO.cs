﻿using Entities;
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
        public City City { get; set; }

        public List<int> CategoryIds { get; set; }
        public List<string> CategoryNames { get; set; }

        public string OwnerUserId { get; set; }

        public List<string> Visitors { get; set; }

        public string Description { get; set; }
    }
}
