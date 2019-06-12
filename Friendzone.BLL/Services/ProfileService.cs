using Friendzone.BLL.DTO;
using Friendzone.BLL.Interfaces;
using FriendZone.DAL.Entities;
using FriendZone.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Friendzone.BLL.Services
{
    public class ProfileService : IProfileService
    {
        public IUnitOfWork Db { get; set; }

        public ProfileService(IUnitOfWork uow)
        {
            Db = uow;
        }



        public void Dispose()
        {
            Db.Dispose();
        }

        public List<UserProfile> Users()
        {
            return Db.ProfileManager.All().ToList();
        }
    }
}
