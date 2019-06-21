using System;
using System.Threading.Tasks;
using AutoMapper;
using Entities;
using Friendzone.Core.DTO;
using Friendzone.Core.IServices;
using Friendzone.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Friendzone.Web.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private IProfileService _profileService;
        private IUserService _userService;
        private IPhotoService _photoService;
        private IMapper _mapper;

        public ProfileController(
            IProfileService profileSrv,
            IUserService userSrv,
            IPhotoService photoSrv,
            IMapper mapper
            )
        {
            _profileService = profileSrv;
            _userService = userSrv;
            _photoService = photoSrv;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            User currentUser = await _userService.GetCurrentUserAsync(HttpContext);
            var profile = _profileService.GetProfile(currentUser);
            var viewModel = _mapper.Map<ProfileDTO, UserProfileViewModel>(profile);

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> ChangeAvatar()
        {
            User currentUser = await _userService.GetCurrentUserAsync(HttpContext);
            ChangeAvatarViewModel model = new ChangeAvatarViewModel { ProfileId = currentUser.ProfileId };

            return View(model);
        }
        
        // Endpoints for API

        [HttpGet("api/[controller]")]
        public IActionResult Get()
        {
            return Ok(_profileService.Users());
        }

        [HttpGet("api/[controller]/{id:int}")]
        public IActionResult Get(int id)
        {
            var profile = _profileService.GetById(id);
            if (profile != null)
            {
                var viewModel = _mapper.Map<ProfileDTO, UserProfileViewModel>(profile);
                return Ok(viewModel);
            }
            return BadRequest();
        }

        [HttpPost("api/[controller]/[action]")]
        public async Task<IActionResult> Edit(UserProfileEditModel model)
        {
            User currentUser = await _userService.GetCurrentUserAsync(HttpContext);

            if (ModelState.IsValid && (model.Id == currentUser.Profile.Id || User.IsInRole("Admin")))
            {
                ProfileDTO profile = _mapper.Map<UserProfileEditModel, ProfileDTO>(model);

                var result = await _profileService.ChangeProfileInfo(profile);

                if (result.Succedeed)
                {
                    return Ok();
                }
            }
            return BadRequest();
        }

        [HttpPost("api/[controller]/[action]")]
        public async Task<IActionResult> ChangeAvatar(ChangeAvatarViewModel model)
        {
            User currentUser = await _userService.GetCurrentUserAsync(HttpContext);

            if (ModelState.IsValid && (model.ProfileId == currentUser.ProfileId || User.IsInRole("Admin")))
            {
                var newAvatar = await _photoService.AddPhoto(model.Image);
                var result = await _profileService.ChangeAvatar(model.ProfileId, newAvatar);
                if (result.Succedeed)
                {
                    await _photoService.Delete(Int32.Parse(result.Message));
                    return Ok(newAvatar.Url);
                }
            }
                
            return BadRequest();
        }
    }
}