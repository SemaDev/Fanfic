using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fanfic.Models.UserViewModels
{
    public class ProfileViewModel
    {
        public DateTime DateOfBirth { get; set; }
        public string Sex { get; set; }
        [Remote(action: "CheckUserName", controller: "Account", ErrorMessage = "E-mail is already taken")]
        public string UserName { get; set; }
        public string RealName { get; set; }
    }
}
