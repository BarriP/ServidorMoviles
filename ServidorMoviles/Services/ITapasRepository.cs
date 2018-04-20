using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServidorMoviles.Models;

namespace ServidorMoviles.Services
{
    public interface ITapasRepository
    {
        IEnumerable<Tapa> GetTapas();
        Tapa GetTapa(int id);
        Tapa NewTapa(Tapa newTapa);
        Tapa ModifyTapa(Tapa modifiedTapa);
        bool DeleteTapa(int tapaId);
        void Save();
    }
}
