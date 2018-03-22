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
using Microsoft.EntityFrameworkCore;

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

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Index(string UserName)
        {
            var model = await FillProfileByName(UserName);

            return View(model);
        }

        private async Task<ProfileViewModel> FillProfileByName(string name)
        {
            var user = await _userManager.FindByNameAsync(name);
            ProfileViewModel model = new ProfileViewModel();
            model.RealName = user.RealName;
            model.Admin = (await _userManager.GetRolesAsync(user)).FirstOrDefault() == "admin";
            model.AboutMe = user.AboutMe;
            model.UserName = user.UserName;
            model.Fanfics = dbContext.Fanfics.Where(f => f.ApplicationUser == user).Include(f => f.Janre).ToList();
            model.Janres = dbContext.Janres.ToList();
            model.Right = await IsUserAdmin(user);
            model.Locked = await _userManager.IsLockedOutAsync(user);
            return model;
        }

        private async Task<ProfileViewModel.Rights> IsUserAdmin(ApplicationUser user)
        {
            string role;
            if ((await CurrentUser()) != null)
                role = (await _userManager.GetRolesAsync((await CurrentUser()))).FirstOrDefault();
            else
                return ProfileViewModel.Rights.User;
            if (role == "admin")
                return ProfileViewModel.Rights.Admin;
            if (user.UserName == User.Identity.Name)
                return ProfileViewModel.Rights.Owner;
            return ProfileViewModel.Rights.User;
        }

        public async Task<IActionResult> SortFilter(int Janre, int Order, string userName)
        {
            var fannfics = dbContext.Fanfics.Where(f => f.Janre.Id == Janre).Where(f => f.ApplicationUser.UserName == userName).ToList();
            if (Janre == 0)
            {
                fannfics = dbContext.Fanfics.Where(f => f.ApplicationUser.UserName == userName).ToList();
            }
            switch (Order)
            {
                case 1:
                    {
                        fannfics = fannfics.OrderBy(f => f.CreateDate).ToList();
                        break;
                    }
                case 2:
                    {
                        fannfics = fannfics.OrderByDescending(f => f.CreateDate).ToList();
                        break;
                    }
                case 3:
                    {
                        fannfics = fannfics.OrderBy(f => f.Name).ToList();
                        break;
                    }
                case 4:
                    {
                        fannfics = fannfics.OrderByDescending(f => f.Name).ToList();
                        break;
                    }
            }
            var model = await FillProfileByName(userName);
            model.Fanfics = fannfics;
            return View("index", model);
        }

        private async Task<ApplicationUser> CurrentUser() => await _userManager.GetUserAsync(User);

        public IActionResult DeleteFanfic(int idfanfic)
        {
            dbContext.Fanfics.Remove(dbContext.Fanfics.Find(idfanfic));
            dbContext.SaveChanges();
            return RedirectToAction("index");
        }


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

        public async Task<IActionResult> Lock(string username)
        {
            ApplicationUser applicationUser = dbContext.Users.Where(user => user.UserName == username).FirstOrDefault();
            if ((await _userManager.IsLockedOutAsync(applicationUser)) != true)
            {
                applicationUser.LockoutEnd = DateTime.UtcNow.AddYears(1000);

            }
            else
                applicationUser.LockoutEnd = DateTime.UtcNow.AddYears(-1000);
            dbContext.Update(applicationUser);
            dbContext.SaveChanges();
            return RedirectToAction("index", new { username = username });
        }

        public async Task<IActionResult> Delete(string username)
        {
            ApplicationUser applicationUser = dbContext.Users.Where(user => user.UserName == username).FirstOrDefault();
            dbContext.Remove(applicationUser);
            dbContext.SaveChanges();
            return RedirectToAction("home", "index");
        }

        public async Task<IActionResult> GiveRigts(string username)
        {
            ApplicationUser applicationUser = dbContext.Users.Where(user => user.UserName == username).FirstOrDefault();
            var role = (await _userManager.GetRolesAsync(applicationUser)).FirstOrDefault();
            if (role == "admin")
                await _userManager.RemoveFromRoleAsync(applicationUser, role);
            else
                await _userManager.AddToRoleAsync(applicationUser, "admin");
            return RedirectToAction("index", new{ username = username });
        }

    }
}
