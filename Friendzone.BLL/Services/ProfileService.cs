using Entities;
using Friendzone.Core.DTO;
using Friendzone.Core.IRepositories;
using Friendzone.Core.IServices;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Friendzone.Core.Services
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

        public ProfileDTO GetProfile(User u)
        {
            var p = Db.ProfileRepository.Get(u.ProfileId);

            return new ProfileDTO
            {
                UserName = u.UserName,
                Email = u.Email,
                PhoneNumber = u.PhoneNumber,
                Birthday = p.Birthday,
                City = p.City?.Name,
                Country = p.City?.Country.Name,
                AvatarUrl = p.Avatar?.Url
            };
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
