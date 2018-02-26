﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fanfic.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public List<FanficTag> FanficTags { get; set; }
    }
}
