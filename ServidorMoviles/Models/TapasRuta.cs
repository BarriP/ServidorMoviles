using System;
using System.Collections.Generic;

namespace ServidorMoviles.Models
{
    public partial class TapasRuta
    {
        public long RutaId { get; set; }
        public long TapaId { get; set; }

        public Ruta Ruta { get; set; }
        public Tapa Tapa { get; set; }
    }
}
