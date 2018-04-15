using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServidorMoviles.Models;
using ServidorMoviles.Models.Form;

namespace ServidorMoviles.Services
{
    public class UserRepository: IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext ctx) => _context = ctx;

        public IEnumerable<Usuario> GetUsuarios() => _context.Usuario.ToList();
        public Usuario GetUsuario(int id) => _context.Usuario.FirstOrDefault(
            u => u.Id == id);
        public Usuario GetUsuario(string username, string password) => _context.Usuario.FirstOrDefault(
            u => u.Username.Equals(username) && 
                 u.Password.Equals(password));

        public Usuario NewUsuario(Usuario newUser) => _context.Usuario.Add(newUser).Entity;
        public Usuario ModifyUser(Usuario modifiedUser)
        {
            _context.Entry(modifiedUser).State = EntityState.Modified;
            return modifiedUser;
        }

        public bool DeleteUser(int userId)
        {
            var user = GetUsuario(userId);
            if (user == null)
                return false;
            _context.Usuario.Remove(user);
            return true;
        }

        public Usuario UserByUsername(string username) =>
            _context.Usuario.FirstOrDefault(u => u.Username.Equals(username));

        public void Save() => _context.SaveChanges();

        #region Dispose
        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
