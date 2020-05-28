using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public class GeneroDALImpl : IGeneroDAL
    {
        private BDContext context;
        public void AddGenero(Genero genero)
        {
            using (context = new BDContext())
            {
                context.Genero.Add(genero);
                context.SaveChanges();
            }
        }

        public void UpdateGenero(Genero genero)
        {
            using (context = new BDContext())
            {
                context.Entry(genero).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteGenero(int id)
        {
            using (context = new BDContext())
            {
                Genero genero;
                genero = (from g in context.Genero
                                 where g.id_genero == id
                                 select g).FirstOrDefault();
                context.Genero.Remove(genero);
                context.SaveChanges();
            }
        }

        public List<Genero> GetGenero()
        {
            List<Genero> result;
            using (context = new BDContext())
            {
                result = (from g in context.Genero
                          select g).ToList();
            }
            return result;
        }

        public Genero GetGeneroById(int id)
        {
            Genero result;
            using (context = new BDContext())
            {
                result = (from g in context.Genero
                          where g.id_genero == id
                          select g).FirstOrDefault();
            }
            return result;
        }
    }
}
