﻿using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Friendzone.Core.DTO
{
    public class ProfileDTO
    {
        public int Id { get; set; }

        public string Email { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }

        public Photo Avatar { get; set; }
        public DateTime Birthday { get; set; }
        public City City { get; set; }
        

    }
}
