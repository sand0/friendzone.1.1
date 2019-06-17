using Entities;
using Friendzone.Core.DTO;
using Friendzone.Core.Infrastructure;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Friendzone.BLL.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task<OperationDetails> CreateAsync(UserDTO userDto);
        Task<bool> AuthenticateAsync(UserDTO userDto);
        Task SignOutAsync();

        Task<User> GetCurrentUserAsync(HttpContext context);

        Task AdminSeedAsync(UserDTO adminDto);
    }


}

