﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Friendzone.BLL.Interfaces;
using FriendZone.DAL.Entities;
using Friendzone.BLL.DTO;
using Friendzone.BLL.Infrastructure;
using Friendzone.Web.Models;

namespace LetsTogether.Web.Controllers
{
    public class AccountController : Controller
    {

        private readonly IUserService _userService;
        
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            await AdminSeedAsync();


            if (ModelState.IsValid)
            {
                UserDTO userDto = new UserDTO
                {
                    Email = model.Email,
                    Password = model.Password
                };
                bool auth = await _userService.AuthenticateAsync(userDto);
                if (auth)
                {
                    return RedirectToAction("Index", "Home");
                }

            }
            ModelState.AddModelError("", "Email or Password is incorect!");
            return View(model);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                UserDTO userDto = new UserDTO
                {
                    Email = model.Email,
                    Password = model.Password,
                    Role = "user",
                    Birthday = model.Birthday,
                    Location = new Location() { Name = model.City_state },
                    Phone = model.Phone,
                    UserName = model.Login
                };

                OperationDetails operationDetails = await _userService.CreateAsync(userDto);

                if (operationDetails.Succedeed)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(operationDetails.Property, operationDetails.Message);
            }
            return View(model);
        }


        public async Task<IActionResult> Logout()
        {
            await _userService.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }


        private async Task AdminSeedAsync()
        {
            await _userService.AdminSeedAsync(new UserDTO
            {
                Email = "admin@gmail.com",
                UserName = "SuperAdmin",
                Password = "!Passw0rd",
                Role = "admin",
            });
        }
    }
}