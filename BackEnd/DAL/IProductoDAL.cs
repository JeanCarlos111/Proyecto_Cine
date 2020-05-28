using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public interface IProductoDAL
    {
        void AddProducto(Producto producto);
        void UpdateProducto(Producto producto);
        void DeleteProducto(int id);
        Producto GetProductoById(int id);
        List<Producto> GetProductos();
    }
}
