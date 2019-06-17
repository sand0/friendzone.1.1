using Friendzone.Core.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Friendzone.Web.Controllers
{
    [Authorize(Roles="Admin")]
    public class AdminController : Controller
    {
        public IUserService UserService { get; set; }
        public IProfileService ProfileService { get; set; }

        public AdminController(IUserService userSrv, IProfileService profileSrv)
        {
            UserService = userSrv;
            ProfileService = profileSrv;
        }

        public IActionResult Index() => View();

        public IActionResult Users() => View(ProfileService.Users());
    }
}