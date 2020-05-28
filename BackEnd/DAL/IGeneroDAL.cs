using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public interface IGeneroDAL
    {
        void AddGenero(Genero genero);
        void UpdateGenero(Genero genero);
        void DeleteGenero(int id);
        List<Genero> GetGenero();
        Genero GetGeneroById(int id);
    }
}
