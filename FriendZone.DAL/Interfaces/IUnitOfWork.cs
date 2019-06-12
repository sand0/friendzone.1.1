using FriendZone.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FriendZone.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        SignInManager<User> SignInManager { get; }

        RoleManager<IdentityRole> RoleManager { get; }

        UserManager<User> UserManager { get; }
        IUserProfileRepository ProfileManager { get; }

        ICountryRepository CountryRepository { get; }
        ICityRepository CityRepository { get; }

        Task SaveAsync();

        void Dispose();
    }
}
