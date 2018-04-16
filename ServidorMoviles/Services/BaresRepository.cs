using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServidorMoviles.Models;

namespace ServidorMoviles.Services
{
    public class BaresRepository : IBaresRepository
    {
        private readonly DataContext _context;
        public BaresRepository(DataContext ctx) => _context = ctx;
    }
}
