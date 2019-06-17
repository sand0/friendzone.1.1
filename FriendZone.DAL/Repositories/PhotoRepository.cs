using FriendZone.DAL.Data;
using FriendZone.DAL.Entities;
using FriendZone.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FriendZone.DAL.Repositories
{
    public class PhotoRepository : Repository<Photo>, IPhotoRepository
    {
        public PhotoRepository(AppDbContext context) : base(context)
        {
        }
    }
}
