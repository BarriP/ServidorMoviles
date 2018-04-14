using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServidorMoviles.Models;

namespace ServidorMoviles.Services
{
    public interface IUserRepository
    {
        IEnumerable<Usuario> GetUsuarios();
        Usuario GetUsuario(int id);
    }
}
