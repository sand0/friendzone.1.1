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

        public IEnumerable<ProfileDTO> Users()
        {
            var profiles = Db.ProfileRepository.AllProfilesWithAllFields();
            var responce = _mapper.Map<IEnumerable<UserProfile>, IEnumerable<ProfileDTO>>(profiles);

            return responce;
        }

        public ProfileDTO GetProfile(User u)
        {
            var profile = Db.ProfileRepository.GetProfileWithAllFields(u.ProfileId);

            return _mapper.Map<UserProfile, ProfileDTO>(profile);
        }

        public ProfileDTO GetById(int id)
        {
            var profile = Db.ProfileRepository.GetProfileWithAllFields(id);

            return _mapper.Map<UserProfile, ProfileDTO>(profile);
        }

        public async Task<OperationDetails> ChangeAvatar(int profileId, Photo newAvatar)
        {
            var profile = Db.ProfileRepository.GetProfileWithAllFields(profileId);
            if (profile == null)
            {
                return new OperationDetails(false, "Profile not found", "");
            }

            int idForDelete = profile.Avatar == null ? 0 : profile.Avatar.Id;

            profile.Avatar = newAvatar;
            Db.ProfileRepository.Update(profile);

            await Db.SaveAsync();
            return new OperationDetails(true, $"{idForDelete}", "Id photo for delete:");
        }

        public async Task<OperationDetails> ChangeProfileInfo(ProfileDTO profile)
        {
            if (profile.Id == 0)
            {
                return new OperationDetails(false, "Id field is '0'", "");
            }

            UserProfile oldProfile = Db.ProfileRepository.GetProfileWithAllFields(profile.Id);
            if (oldProfile == null)
            {
                return new OperationDetails(false, "Not found", "");
            }

            oldProfile.City = profile.City;
            oldProfile.Birthday = profile.Birthday;

            Db.ProfileRepository.Update(oldProfile);

            await Db.SaveAsync();

            return new OperationDetails(true, "", "");
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
