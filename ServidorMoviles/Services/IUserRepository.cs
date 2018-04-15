using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServidorMoviles.Models;
using ServidorMoviles.Models.Form;

namespace ServidorMoviles.Services
{
    public interface IUserRepository
    {
        IEnumerable<Usuario> GetUsuarios();
        Usuario GetUsuario(int id);
        Usuario GetUsuario(string username, string password);
        Usuario NewUsuario(Usuario newUser);
        Usuario ModifyUser(Usuario modifiedUser);
        bool DeleteUser(int userId);
        Usuario UserByUsername(string username);
        void Save();
    }
}
