using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using ServidorMoviles.Utils;

namespace ServidorMoviles.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Comentario = new HashSet<Comentario>();
            Ruta = new HashSet<Ruta>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public string Mail { get; set; }

        [JsonIgnore]
        public string ImageUrl { get; set; }
        public string Image => $"{ConfigurationManager.Instance.HostUrl}/{ImageUrl}";

        public ICollection<Comentario> Comentario { get; set; }
        public ICollection<Ruta> Ruta { get; set; }
    }
}
