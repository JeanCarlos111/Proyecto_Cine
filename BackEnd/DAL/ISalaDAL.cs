using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
   public interface ISalaDAL
    {
        void AddSala(Sala sala );
        void UpdateSala(Sala sala);
        void DeleteSala(int id);
        List<Sala> GetSala();
        Sala GetSalaById(int id);
    }
}
