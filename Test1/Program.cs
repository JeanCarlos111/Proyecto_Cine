using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEnd.DAL;
using BackEnd.Entities;

namespace Test1
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductoDALImpl productoDAL = new ProductoDALImpl();
            Producto compra;
            compra = new Producto {
                id_comida = productoDAL.GetProductos().Count + 1,
                cantidad = "100",
                imagen_comida = "https://i.ytimg.com/vi/IhU0LszeSe4/maxresdefault.jpg",
                nombre = "Prueba",
                precio = "2000"



            };
           
            productoDAL.AddProducto(compra);
        }
    }
}
