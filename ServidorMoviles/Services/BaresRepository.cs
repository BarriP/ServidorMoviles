using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServidorMoviles.Models;

namespace ServidorMoviles.Services
{
    public class BaresRepository : IBaresRepository
    {
        private readonly DataContext _context;
        public BaresRepository(DataContext ctx) => _context = ctx;

        public IEnumerable<Bar> GetBares() => _context.Bar.Include(u => u.Tapa).ToList();

        public Bar GetBar(int id) => _context.Bar.Include(u => u.Tapa).FirstOrDefault(
            b => b.Id == id);

        public Bar NewBar(Bar newBar) => _context.Bar.Add(newBar).Entity;

        public Bar ModifyBar(Bar modifiedBar)
        {
            _context.Entry(modifiedBar).State = EntityState.Modified;
            return modifiedBar;
        }

        public bool DeleteBar(int barId)
        {
            var bar = GetBar(barId);
            if (bar == null)
                return false;
            _context.Bar.Remove(bar);
            return true;
        }

        public void Save() => _context.SaveChanges();

        // Simplemente un random y sacamos 3
        public IEnumerable<Bar> GetDestacados()
        {
            Random r = new Random();
            return _context.Bar.ToList().OrderBy(x => r.Next()).Take(3);
        }

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
