using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public interface IFormatoDAL
    {
        void AddFormato(Formato formato);
        void UpdateFormato(Formato formato);
        void DeleteFormato(int id);
        List<Formato> GetFormato();
        Formato GetFormatoById(int id);
    }
}
