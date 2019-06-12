﻿using Friendzone.BLL.DTO;
using FriendZone.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Friendzone.BLL.Interfaces
{
    public interface IProfileService : IDisposable
    {
        List<UserProfile> Users(); 
    }
}