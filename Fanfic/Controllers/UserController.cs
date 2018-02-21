using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Fanfic.Models;
using Fanfic.Services;
using Fanfic.Models.AccountViewModels;
using Fanfic.Models.UserViewModels;

namespace Fanfic.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger _logger;
        private readonly UrlEncoder _urlEncoder;

        public UserController(
          UserManager<ApplicationUser> userManager,
          SignInManager<ApplicationUser> signInManager,
          ILogger<UserController> logger,
          UrlEncoder urlEncoder)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _urlEncoder = urlEncoder;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await CurrentUser();
            ProfileViewModel model = new ProfileViewModel();
            model.DateOfBirth = user.DateOfBirth;
            model.RealName = user.RealName;
            model.Sex = user.RealName;
            model.UserName = user.UserName;
            return View(model);
        }

        private async Task<ApplicationUser> CurrentUser()
        {
             return await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
        }



    }
}
