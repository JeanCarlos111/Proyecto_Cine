using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public class CompraDALImpl : ICompraDAL
    {
        private BDContext context;
        public void AddCompra(Compra compra)
        {
            using (context = new BDContext())
            {
                context.Compra.Add(compra);
                context.SaveChanges();
            }
        }

        public void UpdateCompra(Compra compra)
        {
            using (context = new BDContext())
            {
                context.Entry(compra).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteCompra(int id)
        {
            using (context = new BDContext())
            {
                Compra compra;
                compra = (from c in context.Compra
                                 where c.id_compra == id
                                 select c).FirstOrDefault();
                context.Compra.Remove(compra);
                context.SaveChanges();
            }
        }

        public Compra GetCompraById(int id)
        {
            Compra result;
            using (context = new BDContext())
            {
                result = (from c in context.Compra
                          where c.id_compra == id
                          select c).FirstOrDefault();
            }
            return result;
        }

        public List<Compra> GetCompras()
        {
            List<Compra> result;
            using (context = new BDContext())
            {
                result = (from c in context.Compra
                          select c).ToList();
            }
            return result;
        }

        
    }
}
