using System;
using System.Collections.Generic;

namespace ServidorMoviles.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Comentario = new HashSet<Comentario>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public string Mail { get; set; }
        public string ImageUrl { get; set; }

        public ICollection<Comentario> Comentario { get; set; }
    }
}
