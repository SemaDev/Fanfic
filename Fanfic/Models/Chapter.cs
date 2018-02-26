using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fanfic.Models
{
    public class Chapter
    {
        public int Id { get; set; }
        public string Caption { get; set; }
        public string Text { get; set; }
        public string Picture { get; set; }
        public Fanfic Fanfic { get; set; }
        public List<Rate> Rate { get; set; }
    }
}
