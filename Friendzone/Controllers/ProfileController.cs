using System;
using System.Threading.Tasks;
using Entities;
using Friendzone.Core.IServices;
using Friendzone.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Friendzone.Web.Controllers
{
    [Authorize]
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
                Email = profile.Email,
                //City =
                Age = DateTime.Today.Year - profile.Birthday.Year
            };

            return View(viewModel);
        }

        //public IActionResult Edit(int id)
        //{
        //    
        //}
    }
}