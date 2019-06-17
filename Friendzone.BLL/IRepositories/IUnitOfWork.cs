using Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Friendzone.Core.IRepositories
{
    public interface IUnitOfWork
    {
        SignInManager<User> SignInManager { get; }
        RoleManager<IdentityRole> RoleManager { get; }
        UserManager<User> UserManager { get; }
        IUserProfileRepository ProfileRepository { get; }
        ICountryRepository CountryRepository { get; }
        ICityRepository CityRepository { get; }
        ICategoryRepository CategoryRepository { get; }

        Task SaveAsync();

        void Dispose();
    }
}
