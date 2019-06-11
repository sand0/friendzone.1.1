using FriendZone.DAL.Data;
using FriendZone.DAL.Entities;
using FriendZone.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FriendZone.DAL.Repositories
{
    public class LocationRepository : Repository<Location>, ILocationRepository
    {
        public LocationRepository(AppDbContext context) : base(context)
        {
        }
    }
}
