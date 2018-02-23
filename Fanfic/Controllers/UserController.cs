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
using Fanfic.Data;

namespace Fanfic.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class UserController : Controller
    {
        private ApplicationDbContext dbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger _logger;
        private readonly UrlEncoder _urlEncoder;

        public UserController(
          UserManager<ApplicationUser> userManager,
          SignInManager<ApplicationUser> signInManager,
          ILogger<UserController> logger,
          UrlEncoder urlEncoder,
          ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _urlEncoder = urlEncoder;
            dbContext = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await CurrentUser();
            ProfileViewModel model = new ProfileViewModel();
            model.RealName = user.RealName;
            model.Sex = user.RealName;
            model.UserName = user.UserName;
            return View(model);
        }

        private async Task<ApplicationUser> CurrentUser()
        {
             return await _userManager.GetUserAsync(User);
        }

        //public async Task<IActionResult> CheckUserName(int pk, string value, string name)
        //{
        //    if (value == null)
        //        return StatusCode(400, "Enter user name");
        //    if ((await _userManager.FindByNameAsync(value)) == null | name == User.Identity.Name)
        //    {
        //        await AlterUserName(value);
        //        return StatusCode(200);
        //    }
        //    return StatusCode(400, "User name is already taken");
        //}


        [AcceptVerbs("Get", "Post")]
        public async Task<IActionResult> SetRtealName(string name, string value, string pk)
        {
            ApplicationUser user = await CurrentUser();
            user.RealName = value;
            dbContext.Update(user);
            await dbContext.SaveChangesAsync();
            return StatusCode(200);
        }

        [AcceptVerbs("Get", "Post")]
        public async Task<IActionResult> SetAboutMe(int pk, string value, string name)
        {
            ApplicationUser user = await CurrentUser();
            user.AboutMe = value;
            dbContext.Update(user);
            await dbContext.SaveChangesAsync();
            return StatusCode(200);
        }

    }
}
