using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fanfic.Models.UserViewModels
{
    public class ProfileViewModel
    {
        public int Id { get; set; }
        public string AboutMe { get; set; }
        public string Sex { get; set; }
        public string UserName { get; set; }
        public string RealName { get; set; }

        public List<Fanfic> Fanfics { get; set; }
        public List<Janre> Janres { get; set; }
    }
}
