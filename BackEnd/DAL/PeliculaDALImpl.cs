using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public class PeliculaDALImpl : IPeliculaDAL
    {
        private BDContext context;
        public void AddPelicula(Pelicula pelicula)
        {
            using (context = new BDContext()) {
                context.Pelicula.Add(pelicula);
                context.SaveChanges();
            }
        }

        public void UpdatePelicula(Pelicula pelicula)
        {
            using (context = new BDContext())
            {
                context.Entry(pelicula).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeletePelicula(int id)
        {
            using (context = new BDContext())
            {
                Pelicula pelicula;
                pelicula = (from p in context.Pelicula
                              where p.id_pelicula == id
                              select p).FirstOrDefault();
                context.Pelicula.Remove(pelicula);
                context.SaveChanges();
            }
        }

        public List<Pelicula> GetPeliculas()
        {
            List<Pelicula> result;
            using (context = new BDContext())
            {
                result = (from p in context.Pelicula
                          select p).ToList();
            }
            return result;
        }

        public Pelicula GetPeliculaById(int id)
        {
            Pelicula result;
            using (context = new BDContext())
            {
                result = (from p in context.Pelicula
                          where p.id_pelicula == id
                          select p).FirstOrDefault();
            }
            return result;
        }
    }
}
