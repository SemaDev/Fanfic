using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fanfic.Models
{
    public class Janre
    {
        public int Id { get; set; }
        public int Caption { get; set; }
        public Fanfic Fanfic { get; set; }
        public int Id_Fanfic { get; set; }

    }
}
