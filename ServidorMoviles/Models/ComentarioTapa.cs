using System;
using System.Collections.Generic;

namespace ServidorMoviles.Models
{
    public partial class ComentarioTapa
    {
        public long TapaId { get; set; }
        public long ComentarioId { get; set; }

        public Comentario Comentario { get; set; }
        public Tapa Tapa { get; set; }
    }
}
