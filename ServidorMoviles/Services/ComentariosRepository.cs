using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServidorMoviles.Models;

namespace ServidorMoviles.Services
{
    public class ComentariosRepository : IComentariosRepository
    {
        private readonly DataContext _context;
        public ComentariosRepository(DataContext ctx) => _context = ctx;
    }
}
