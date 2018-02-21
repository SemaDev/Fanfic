using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Fanfic.Models
{
    public class Fanfic
    {
        public int Id { get; set;  }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime CreateDate { get; set; }
        public List<Tag> Tags { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Chapter> Chapters { get; set; }
        public List<Janre> Janre { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        public int Id_ApplicationUser { get; set; }
    }

}
