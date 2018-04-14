using System;
using System.Collections.Generic;

namespace ServidorMoviles.Models
{
    public partial class Ruta
    {
        public long Id { get; set; }
        public long? Name { get; set; }
        public long? Description { get; set; }
    }
}
