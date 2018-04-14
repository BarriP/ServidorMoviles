using System;
using System.Collections.Generic;

namespace ServidorMoviles.Models
{
    public partial class Tapas
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public long Category { get; set; }
        public string PhotoUrl { get; set; }
        public string Description { get; set; }
        public string Rating { get; set; }
    }
}
