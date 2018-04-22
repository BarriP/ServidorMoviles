using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServidorMoviles.Models;

namespace ServidorMoviles.Services
{
    public interface IBaresRepository
    {
        IEnumerable<Bar> GetBares();
        Bar GetBar(int id);
        Bar NewBar(Bar newBar);
        Bar ModifyBar(Bar modifiedBar);
        bool DeleteBar(int barId);
        void Save();
        IEnumerable<Bar> GetDestacados();
    }
}
