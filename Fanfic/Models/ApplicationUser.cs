using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Fanfic.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string AboutMe { get; set; }
        public string RealName { get; set; }
        public List<Fanfic> Fanfics { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Rate> Rates { get; set; }
        public List<CommentLike> CommnetLike { get; set; }
    }
}
