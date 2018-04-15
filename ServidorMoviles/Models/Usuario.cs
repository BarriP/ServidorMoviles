using System;
using System.Collections.Generic;
using ServidorMoviles.Services;

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

        private string _imageUrl;
        public string ImageUrl
        {
            set => _imageUrl = value;
            get => $"{ConfigurationManager.Instance.HostUrl}/{_imageUrl}";
        }

        public ICollection<Comentario> Comentario { get; set; }
    }
}
