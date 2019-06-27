using Friendzone.Core.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Friendzone.Web.Controllers
{
    [Authorize(Roles="Admin")]
    public class AdminController : Controller
    {
        private IUserService _userService;
        private IProfileService _profileService;

        public AdminController(IUserService userSrv, IProfileService profileSrv)
        {
            _userService = userSrv;
            _profileService = profileSrv;
        }

        public IActionResult Index() => View();

        public IActionResult Users() => View(_profileService.Users());
    }
}