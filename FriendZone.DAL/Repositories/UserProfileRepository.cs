using FriendZone.DAL.Data;
using FriendZone.DAL.Entities;
using FriendZone.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FriendZone.DAL.Repositories
{
    public class UserProfileRepository : Repository<UserProfile>, IUserProfileRepository
    {
        public UserProfileRepository(AppDbContext context) : base(context)
        {
        }
    }
}
