using Friendzone.BLL.DTO;
using Friendzone.BLL.Interfaces;
using FriendZone.DAL.Entities;
using FriendZone.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Friendzone.BLL.Services
{
    public class ProfileService : IProfileService
    {
        public IUnitOfWork Db { get; set; }

        public ProfileService(IUnitOfWork uow)
        {
            Db = uow;
        }


        public List<ProfileDTO> Users()
        {
            var profiles = Db.ProfileRepository.All()
                .Include(p => p.User)
                .Include(p => p.City)
                    .ThenInclude(c => c.Country)
                .ToList();
            var responce = new List<ProfileDTO>();

            foreach (var p in profiles)
            {
                responce.Add(new ProfileDTO
                {
                    UserName = p.User.UserName,
                    Email = p.User.Email,
                    PhoneNumber = p.User.PhoneNumber,
                    Birthday = p.Birthday,
                    City = p.City.Name,
                    Country = p.City.Country.Name,
                    AvatarUrl = p.Avatar?.Url
                });
            }

            return responce;
        }


        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
