using Friendzone.BLL.DTO;
using Friendzone.BLL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Friendzone.BLL.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task<OperationDetails> CreateAsync(UserDTO userDto);
        Task<bool> AuthenticateAsync(UserDTO userDto);
        Task SignOutAsync();

        Task AdminSeedAsync(UserDTO adminDto);
    }


}

