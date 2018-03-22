using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Fanfic.Models;
using Fanfic.Data;
using Microsoft.EntityFrameworkCore;

namespace Fanfic.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext dbContext;


        public HomeController(ApplicationDbContext context)
        {
            dbContext = context;
        }
        public IActionResult Index()
        {
            List<Models.Fanfic> fanfics = dbContext.Fanfics.Include(f=>f.Janre).Include(f=>f.ApplicationUser).OrderBy(f => f.CreateDate).ToList();
            return View(fanfics);
        }

    }
}
