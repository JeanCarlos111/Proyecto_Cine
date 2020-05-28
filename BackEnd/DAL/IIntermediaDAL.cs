using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public interface IIntermediaDAL
    {
        void AddIntermedia(Intermedia intermedia);
        void UpdateIntermedia(Intermedia intermedia);
        void DeleteIntermedia(int id);
        List<Intermedia> GetIntermedios();
    }
}
