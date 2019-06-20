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
        List<ProfileDTO> Users();
        ProfileDTO GetProfile(User u);
        Task<OperationDetails> EditAsync(ProfileDTO profile);
    }
}
