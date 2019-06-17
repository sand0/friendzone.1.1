using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Friendzone.BLL.Interfaces;
using Friendzone.Web.Models;
using FriendZone.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Friendzone.Web.Controllers
{
    public class ProfileController : Controller
    {
        private IProfileService _profileService;
        private IUserService _userService;

        public ProfileController(
            IProfileService profileSrv,
            IUserService userSrv
            )
        {
            _profileService = profileSrv;
            _userService = userSrv;
        }

        public async Task<IActionResult> Index()
        {
            User currentUser = await _userService.GetCurrentUserAsync(HttpContext);

            var profile = _profileService.GetProfile(currentUser);

            var viewModel = new UserProfileViewModel
            {
                AvatarUrl = profile.AvatarUrl,
                UserName = profile.UserName,
                Email =profile.Email,
                //City =
                Age = profile.Birthday.Year - DateTime.Today.Year
            };

            return View(viewModel);
        }
    }
}