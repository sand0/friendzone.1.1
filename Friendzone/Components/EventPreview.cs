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
        private ICityService _cityService;
        private ICategoryService _categoryService;

        public EventPreview(
           IProfileService profileSrv,
           IUserService userSrv,
           ICityService citySrv,
           ICategoryService categorySrv
           )
        {
            _profileService = profileSrv;
            _userService = userSrv;
            _cityService = citySrv;
            _categoryService = categorySrv;
        }

        public async Task<IViewComponentResult> InvokeAsync(EventDTO ev)
        {
            //find city:
            ev.City = _cityService.Get(ev.CityId);

            // fix visitors if it's null:
            if (ev.Visitors == null)
            {
                ev.Visitors = new List<string>();
            }

            // find categories:
            if (ev.CategoryIds == null)
            {
                ev.CategoryNames = ev.CategoryIds.Select
                    (
                        x => _categoryService.Get(x).Name
                    )
                    .ToList();
            }

            return View(ev);
        }
    }
}
