using Friendzone.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Friendzone.Core.IServices
{
    public interface IProfileService : IDisposable
    {
        List<ProfileDTO> Users();
        ProfileDTO GetProfile(User u);
    }
}
