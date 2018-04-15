using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServidorMoviles.Models.Form
{
    public class UsuarioCreate
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }
        [Required]
        [MinLength(3)]
        public string Password { get; set; }
        [Required]
        [MinLength(3)]
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        public string Mail { get; set; }
    }
}
