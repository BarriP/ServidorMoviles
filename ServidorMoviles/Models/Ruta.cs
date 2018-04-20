using System;
using System.Collections.Generic;

namespace ServidorMoviles.Models
{
    public partial class Ruta
    {
        public Ruta()
        {
            ComentarioRuta = new HashSet<ComentarioRuta>();
            TapasRuta = new HashSet<TapasRuta>();
        }

        public long Id { get; set; }
        public long? Name { get; set; }
        public long? Description { get; set; }
        public long? UserId { get; set; }
        public string Rating { get; set; }

        public Usuario User { get; set; }
        public ICollection<ComentarioRuta> ComentarioRuta { get; set; }
        public ICollection<TapasRuta> TapasRuta { get; set; }
    }
}
