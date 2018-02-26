using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fanfic.Models
{
    public class CommentLike
    {
        public int Id { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public Comment Comment { get; set; }

    }
}
