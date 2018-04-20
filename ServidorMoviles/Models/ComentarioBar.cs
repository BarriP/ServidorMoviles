using System;
using System.Collections.Generic;

namespace ServidorMoviles.Models
{
    public partial class ComentarioBar
    {
        public long BarId { get; set; }
        public long ComentarioId { get; set; }

        public Bar Bar { get; set; }
        public Comentario Comentario { get; set; }
    }
}
