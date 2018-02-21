using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fanfic.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Id_Fanfic { get; set; }
        public Fanfic Fanfic { get; set; }
        public List <CommentLike> CommentLikes { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int Id_ApplicationUser { get; set; }
    }
}
