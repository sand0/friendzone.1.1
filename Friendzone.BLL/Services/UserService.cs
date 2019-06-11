﻿using Friendzone.BLL.DTO;
using Friendzone.BLL.Infrastructure;
using Friendzone.BLL.Interfaces;
using FriendZone.DAL.Entities;
using FriendZone.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Friendzone.BLL.Services
{
    public class UserService : IUserService
    {
        public IUnitOfWork Db { get; set; }

        public UserService(IUnitOfWork uow)
        {
            Db = uow;
        }

        public async Task<OperationDetails> CreateAsync(UserDTO userDto)
        {
            if (await Db.UserManager.FindByEmailAsync(userDto.Email) != null)
            {
                return new OperationDetails(false, "Emali is exist in database", "Email");
            }

            User user = new User
            {
                Email = userDto.Email,
                UserName = userDto.UserName,
                PhoneNumber = userDto.Phone
            };
            var result = await Db.UserManager.CreateAsync(user, userDto.Password);

            if (result.Errors.Count() > 0)
            {
                return new OperationDetails(false, result.Errors.FirstOrDefault().ToString(), "");
            }

            // Add role
            await Db.UserManager.AddToRoleAsync(user, userDto.Role);

            //Location location = Db.LocationRepository.All().Where(l => l.Name == userDto.Location.Name).FirstOrDefault();
            //if (location == null)
            //{
            //    location = userDto.Location;
            //    Db.LocationRepository.Create(userDto.Location);
            //}

            UserProfile userProfile = new UserProfile
            {
                UserId = user.Id,
                Birthday = userDto.Birthday,
                //Location = location
            };
            Db.ProfileManager.Create(userProfile);

            await Db.SaveAsync();

            return new OperationDetails(true, "Registration succeeded", "");
        }

        public async Task<bool> AuthenticateAsync(UserDTO userDto)
        {
            User user = await Db.UserManager.FindByEmailAsync(userDto.Email);
            
            var result = await Db.SignInManager.PasswordSignInAsync(user.UserName, userDto.Password, false, lockoutOnFailure: false);
            
            return result.Succeeded;
        }

        public async Task SignOutAsync()
        {
            await Db.SignInManager.SignOutAsync();
        }

        public async Task AdminSeedAsync(UserDTO adminDto)
        {
            if (!Db.UserManager.Users.Any())
            {
                await CreateAsync(adminDto);
            }
        }

        public void Dispose()
        {
            Db.Dispose();
        }

        
    }
}
