using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServidorMoviles.Models;

namespace ServidorMoviles.Services
{
    public class RutasRepository : IRutasRepository
    {
        private readonly DataContext _context;
        public RutasRepository(DataContext ctx) => _context = ctx;
    }
}
