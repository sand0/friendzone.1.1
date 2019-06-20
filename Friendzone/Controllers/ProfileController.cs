using System;
using System.Threading.Tasks;
using AutoMapper;
using Entities;
using Friendzone.Core.DTO;
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
        private IMapper _mapper;

        public ProfileController(
            IProfileService profileSrv,
            IUserService userSrv,
            IMapper mapper
            )
        {
            _profileService = profileSrv;
            _userService = userSrv;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            User currentUser = await _userService.GetCurrentUserAsync(HttpContext);

            var profile = _profileService.GetProfile(currentUser);

            var viewModel = new UserProfileViewModel
            {
                //AvatarUrl = profile.AvatarUrl,
                UserName = profile.UserName,
                Email = profile.Email,
                //City =
                Age = DateTime.Today.Year - profile.Birthday.Year
            };

            return View(viewModel);
        }


        public async Task<IActionResult> Edit(UserProfileEditModel model)
        {
            User currentUser = await _userService.GetCurrentUserAsync(HttpContext);

            if (ModelState.IsValid && (model.Id == currentUser.Profile.Id || User.IsInRole("Admin")))
            {
                ProfileDTO profile = _mapper.Map<UserProfileEditModel, ProfileDTO>(model);
                if (model.Avatar != null)
                {
                    profile.Avatar = new Photo { }; // TODO: load photo using _fileService
                }

                var result = await _profileService.EditAsync(profile);

                if (result.Succedeed)
                {
                    return Ok();
                }
            }
            return BadRequest();
        }
        
    }
}