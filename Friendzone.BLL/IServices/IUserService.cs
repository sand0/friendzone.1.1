using Friendzone.BLL.DTO;
using Friendzone.BLL.Infrastructure;
using FriendZone.DAL.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
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

