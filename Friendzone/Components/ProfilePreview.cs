using Entities;
using Friendzone.Core.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Friendzone.Web.Components
{
    public class ProfilePreview : ViewComponent
    {
        private IProfileService _profileService;
        private IUserService _userService;

        public ProfilePreview(
            IProfileService profileSrv,
            IUserService userSrv
            )
        {
            _profileService = profileSrv;
            _userService = userSrv;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            User currentUser = await _userService.GetCurrentUserAsync(HttpContext);
            var profile = _profileService.GetById(currentUser.ProfileId);

            return View(profile);
            
        }

        
    }
}

