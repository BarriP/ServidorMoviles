using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServidorMoviles.Models;

namespace ServidorMoviles.Services
{
    public class TapasRepository : ITapasRepository
    {
        private readonly DataContext _context;
        public TapasRepository(DataContext ctx) => _context = ctx;

        public IEnumerable<Tapa> GetTapas()=> _context.Tapa.ToList();

        public Tapa GetTapa(int id) => _context.Tapa.FirstOrDefault(
            t => t.Id == id);

        public Tapa NewTapa(Tapa newTapa) => _context.Tapa.Add(newTapa).Entity;

        public Tapa ModifyTapa(Tapa modifiedTapa)
        {
            _context.Entry(modifiedTapa).State = EntityState.Modified;
            return modifiedTapa;
        }

        public bool DeleteTapa(int tapaId)
        {
            var tapa = GetTapa(tapaId);
            if (tapa == null)
                return false;
            _context.Tapa.Remove(tapa);
            return true;
        }

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
