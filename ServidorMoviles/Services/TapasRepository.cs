using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServidorMoviles.Models;

namespace ServidorMoviles.Services
{
    public class TapasRepository : ITapasRepository
    {
        private readonly DataContext _context;
        public TapasRepository(DataContext ctx) => _context = ctx;
    }
}
