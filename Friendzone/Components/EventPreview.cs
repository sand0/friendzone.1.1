using Friendzone.Core.DTO;
using Friendzone.Core.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Friendzone.Web.Components
{
    public class EventPreview : ViewComponent
    {
        private IProfileService _profileService;
        private IUserService _userService;

        public EventPreview(
           IProfileService profileSrv,
           IUserService userSrv
           )
        {
            _profileService = profileSrv;
            _userService = userSrv;
        }

        public async Task<IViewComponentResult> InvokeAsync(EventDTO ev)
        {
            return View(ev);
        }
    }
}
