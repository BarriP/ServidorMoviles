﻿using System;
using System.Collections.Generic;

namespace ServidorMoviles.Models
{
    public partial class Bares
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Lat { get; set; }
        public string Lon { get; set; }
        public string Rating { get; set; }
    }
}
