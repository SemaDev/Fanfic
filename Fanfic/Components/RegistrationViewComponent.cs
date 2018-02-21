using Fanfic.Models.AccountViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fanfic.Components
{
    public class RegistrationViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(new RegisterViewModel());
        }
    }
}
