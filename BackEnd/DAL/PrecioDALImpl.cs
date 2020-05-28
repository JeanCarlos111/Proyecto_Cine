using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public class PrecioDALImpl : IPrecioDAL
    {
        private BDContext context;
        public Precio GetPrecioById(int id)
        {
            Precio result;
            using (context = new BDContext())
            {
                result = (from c in context.Precio
                          select c).FirstOrDefault();
            }
            return result;
        }

        public List<Precio> GetPrecios()
        {
            List<Precio> result;
            using (context = new BDContext())
            {
                result = (from c in context.Precio
                          select c).ToList();
            }
            return result;
        }
    }
}
