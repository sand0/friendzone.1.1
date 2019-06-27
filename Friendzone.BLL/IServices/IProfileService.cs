using Entities;
using Friendzone.Core.DTO;
using Friendzone.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Friendzone.Core.IServices
{
    public interface IProfileService : IDisposable
    {
        IEnumerable<ProfileDTO> Users();
        ProfileDTO GetProfile(User u);
        ProfileDTO GetById(int id);
        ProfileDTO GetById(string id);
        
        Task<OperationDetails> ChangeAvatar(int profileId, Photo newAvatar);
        Task<OperationDetails> ChangeProfileInfo(ProfileDTO profile);

        Task<OperationDetails> EditFavoriteCategories(int profileId, Dictionary<string, string> categories);
    }
}
