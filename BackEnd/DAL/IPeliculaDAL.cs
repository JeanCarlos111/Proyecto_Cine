using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public interface IPeliculaDAL
    {
        void AddPelicula(Pelicula pelicula);
        void UpdatePelicula(Pelicula pelicula);
        void DeletePelicula(int id);
        List<Pelicula> GetPeliculas();

        Pelicula GetPeliculaById(int id);
    }
}
