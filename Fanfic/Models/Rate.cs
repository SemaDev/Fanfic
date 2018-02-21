using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fanfic.Models
{
    public class Rate
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public Chapter Chapter { get; set; }
        public int Id_Chapter { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int Id_ApplicationUser { get; set; }
    }
}
