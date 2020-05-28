using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public interface IAsientoDAL
    {
        void AddAsiento(Asiento asiento);
        void UpdateAsiento(Asiento asiento);
        void DeleteAsiento(int id);
        Asiento GetAsiento(string numero_asiento);
        List<Asiento> GetAsientosBySala(int idsala);
    }
}
