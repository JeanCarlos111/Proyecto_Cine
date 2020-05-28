using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public class ProductoDALImpl : IProductoDAL
    {
        private BDContext context;
        public void AddProducto(Producto producto)
        {
            using (context = new BDContext())
            {
                context.Producto.Add(producto);
                context.SaveChanges();
            }
        }

        public void UpdateProducto(Producto producto)
        {
            using (context = new BDContext())
            {
                context.Entry(producto).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteProducto(int id)
        {
            using (context = new BDContext())
            {
                Producto producto;
                producto = (from s in context.Producto
                           where s.id_comida == id
                           select s).FirstOrDefault();
                context.Producto.Remove(producto);
                context.SaveChanges();
            }
        }

        public Producto GetProductoById(int id)
        {
            Producto result;
            using (context = new BDContext())
            {
                result = (from p in context.Producto
                          where p.id_comida == id
                          select p).FirstOrDefault();

            }
            return result;
        }

        public List<Producto> GetProductos()
        {
            List<Producto> result;
            using (context = new BDContext())
            {
                result = (from p in context.Producto
                          select p).ToList();

            }
            return result;
        }

        
    }
}
