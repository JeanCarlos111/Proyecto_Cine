using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public class AsientoDALImpl : IAsientoDAL
    {
        private BDContext context;
        public void AddAsiento(Asiento asiento)
        {
            using (context = new BDContext())
            {
                context.Asiento.Add(asiento);
                context.SaveChanges();
            }
        }

        public void UpdateAsiento(Asiento asiento)
        {
            using (context = new BDContext())
            {
                context.Entry(asiento).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteAsiento(int id)
        {
            using (context = new BDContext())
            {
                Asiento asiento;
                asiento = (from s in context.Asiento
                        where s.id_asiento == id
                        select s).FirstOrDefault();
                context.Asiento.Remove(asiento);
                context.SaveChanges();
            }
        }

        public List<Asiento> GetAsientosBySala(int id_sala)
        {
            List<Asiento> result;
            using (context = new BDContext())
            {
                result = (from a in context.Asiento
                          from i in context.Intermedia
                          where a.id_asiento == i.id_asiento && i.id_sala == id_sala
                          select a).ToList();
                          
            }
            return result;
        }

        public Asiento GetAsiento(string numero_asiento)
        {
            Asiento asiento;
            using (context = new BDContext())
            {

                asiento = (from s in context.Asiento
                           where s.numero_asiento == numero_asiento
                           select s).FirstOrDefault();
                
                }
            return asiento;
        }
    }
}
