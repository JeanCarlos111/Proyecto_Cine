using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public class IntermediaDALImpl : IIntermediaDAL
    {
        private BDContext context;
        public void AddIntermedia(Intermedia intermedia)
        {
            using (context = new BDContext())
            {
                context.Intermedia.Add(intermedia);
                context.SaveChanges();
            }
        }
        public void UpdateIntermedia(Intermedia intermedia)
        {
            using (context = new BDContext())
            {
                context.Entry(intermedia).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
        public void DeleteIntermedia(int id)
        {
            using (context = new BDContext())
            {
                Intermedia intermedia;
                intermedia = (from i in context.Intermedia
                           where i.id_intermedia == id
                           select i).FirstOrDefault();
                context.Intermedia.Remove(intermedia);
                context.SaveChanges();
            }
        }

        public List<Intermedia> GetIntermedios()
        {
            List<Intermedia> result;
            using (context = new BDContext())
            {
                result = (from f in context.Intermedia
                          select f).ToList();
            }
            return result;
        }

      
    }
}
