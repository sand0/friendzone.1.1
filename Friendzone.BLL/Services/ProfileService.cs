using AutoMapper;
using Entities;
using Friendzone.Core.DTO;
using Friendzone.Core.Infrastructure;
using Friendzone.Core.IRepositories;
using Friendzone.Core.IServices;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Friendzone.Core.Services
{
    public class ProfileService : IProfileService
    {
        private IMapper _mapper;
        public IUnitOfWork Db { get; set; }

        public ProfileService(IUnitOfWork uow, IMapper mapper)
        {
            Db = uow;
            _mapper = mapper;
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
                    City = p.City,
                });
            }

            return responce;
        }

        public ProfileDTO GetProfile(User u)
        {
            var profileDto = Db.ProfileRepository.GetProfileWithAllFields(u.ProfileId);

            return _mapper.Map<UserProfile, ProfileDTO>(profileDto);
        }

        public async Task<OperationDetails> EditAsync(ProfileDTO profile)
        {
            if(profile.Id == 0)
            {
                return new OperationDetails(false, "Id field is '0'", "");
            }

            UserProfile oldProfile = Db.ProfileRepository.GetProfileWithAllFields(profile.Id);
            if (oldProfile == null)
            {
                return new OperationDetails(false, "Not found", "");
            }

            //update
            //oldProfile.Name = profile.Name;
            UserProfile newProfile = _mapper.Map<ProfileDTO, UserProfile>(profile);

            oldProfile = newProfile;

            await Db.SaveAsync();

            return new OperationDetails(true, "", "");
            
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
