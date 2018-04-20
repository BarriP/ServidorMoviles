using System;
using System.Collections.Generic;

namespace ServidorMoviles.Models
{
    public partial class Comentario
    {
        public Comentario()
        {
            ComentarioBar = new HashSet<ComentarioBar>();
            ComentarioRuta = new HashSet<ComentarioRuta>();
            ComentarioTapa = new HashSet<ComentarioTapa>();
        }

        public long Id { get; set; }
        public string Comment { get; set; }
        public string Rating { get; set; }
        public long UserId { get; set; }

        public Usuario User { get; set; }
        public ICollection<ComentarioBar> ComentarioBar { get; set; }
        public ICollection<ComentarioRuta> ComentarioRuta { get; set; }
        public ICollection<ComentarioTapa> ComentarioTapa { get; set; }
    }
}
