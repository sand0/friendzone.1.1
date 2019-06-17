using Friendzone.Core.DTO;
using Friendzone.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Friendzone.Core.IServices
{
    public interface IUserService : IDisposable
    {
        Task<OperationDetails> CreateAsync(UserDTO userDto);
        Task<bool> AuthenticateAsync(UserDTO userDto);
        Task SignOutAsync();

        Task AdminSeedAsync(UserDTO adminDto);
    }


}

