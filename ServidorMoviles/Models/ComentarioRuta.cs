using System;
using System.Collections.Generic;

namespace ServidorMoviles.Models
{
    public partial class ComentarioRuta
    {
        public long RutaId { get; set; }
        public long ComentarioId { get; set; }

        public Comentario Comentario { get; set; }
        public Ruta Ruta { get; set; }
    }
}
