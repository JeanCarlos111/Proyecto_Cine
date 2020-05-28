using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public class FormatoDALImpl : IFormatoDAL
    {
        private BDContext context;
        public void AddFormato(Formato formato)
        {
            using (context = new BDContext())
            {
                context.Formato.Add(formato);
                context.SaveChanges();
            }
        }

        public void UpdateFormato(Formato formato)
        {
            using (context = new BDContext())
            {
                context.Entry(formato).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteFormato(int id)
        {
            using (context = new BDContext())
            {
                Formato formato;
                formato = (from f in context.Formato
                                 where f.id_formato == id
                                 select f).FirstOrDefault();
                context.Formato.Remove(formato);
                context.SaveChanges();
            }
        }

        public List<Formato> GetFormato()
        {
            List<Formato> result;
            using (context = new BDContext())
            {
                result = (from f in context.Formato
                          select f).ToList();
            }
            return result;
        }

        public Formato GetFormatoById(int id)
        {
            Formato result;
            using (context = new BDContext())
            {
                result = (from f in context.Formato
                          where f.id_formato == id
                          select f).FirstOrDefault();
            }
            return result;
        }
    }
}
