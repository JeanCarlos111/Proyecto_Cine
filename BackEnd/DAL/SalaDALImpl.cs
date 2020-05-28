using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public class SalaDALImpl : ISalaDAL
    {
        private BDContext context;
        public void AddSala(Sala sala)
        {
            using (context = new BDContext())
            {
                context.Sala.Add(sala);
                context.SaveChanges();
            }
        }

        public void UpdateSala(Sala sala)
        {

            using (context = new BDContext())
            {
                context.Entry(sala).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteSala(int id)
        {
            using (context = new BDContext())
            {
                Sala sala;
                sala = (from s in context.Sala
                           where s.id_sala == id
                           select s).FirstOrDefault();
                context.Sala.Remove(sala);
                context.SaveChanges();
            }
        }

        public List<Sala> GetSala()
        {
            List<Sala> result;
            using (context = new BDContext())
            {
                result = (from s in context.Sala
                          select s).ToList();
            }
            return result;
        }

        public Sala GetSalaById(int id)
        {
            Sala result;
            using (context = new BDContext())
            {
                result = (from s in context.Sala
                          where s.id_sala == id
                          select s).FirstOrDefault();
            }
            return result;
        }
    }
}
