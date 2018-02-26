using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fanfic.Models
{
    public class FanficTag
    {
        public Fanfic Fanfic { get; set; }
        public Tag Tag { get; set; }
        public int TagId { get; set; }
        public int FanficId { get; set; }
    }
}
