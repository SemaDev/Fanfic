using Fanfic.Models.AccountViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fanfic.Components
{
    public class LoginViewComponent : ViewComponent 
    {
        public IViewComponentResult Invoke()
        {
            return View(new LoginViewModel());
        }
    }
}
