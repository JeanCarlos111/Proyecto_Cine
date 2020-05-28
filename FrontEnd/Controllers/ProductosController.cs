using BackEnd.DAL;
using BackEnd.Entities;
using FrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace FrontEnd.Controllers
{
    
    public class ProductosController : Controller
    {
        // GET: Comidas
        public ActionResult Index()
        {
            ProductoDALImpl productoDAL = new ProductoDALImpl();
            List<Producto> productos;

            productos = productoDAL.GetProductos();
            


            List<ProductoViewModel> productoVM = new List<ProductoViewModel>();

            ProductoViewModel productoViewModel;
            foreach (var item in productos)
            {

                productoViewModel = new ProductoViewModel()
                {
                    id_comida = item.id_comida,
                    cantidad = item.cantidad,
                    nombre = item.nombre,
                    precio = item.precio,
                    imagen_comida = item.imagen_comida
                };
                productoVM.Add(productoViewModel);
            }



            return View(productoVM);
        }

        public ActionResult Create()
        {
            ProductoViewModel comidas = new ProductoViewModel();
            return View(comidas);
        }
        
        [HttpPost]
        public ActionResult Create(ProductoViewModel productoViewModel)
        {
            ProductoDALImpl productoDAL = new ProductoDALImpl();
            string mensaje = "";
            try
            {
                mensaje = "Agregado con exito";


                Producto producto = new Producto()
                {

                    nombre = productoViewModel.nombre,
                    precio = productoViewModel.precio,
                    cantidad = productoViewModel.cantidad,
                    imagen_comida = productoViewModel.imagen_comida
                };

                
                    producto.id_comida = productoDAL.GetProductos().Count + 1;

                    productoDAL.AddProducto(producto);
                
            }
            catch (Exception ex)
            {
                mensaje = ex.ToString();
            }
            TempData["mensaje"] = mensaje;
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            ProductoDALImpl productoDAL = new ProductoDALImpl();
            ProductoViewModel productoViewModel;
            Producto producto;

            producto = productoDAL.GetProductoById(id);
            
            productoViewModel = new ProductoViewModel()
            {
                id_comida = producto.id_comida,
                nombre = producto.nombre,
                precio = producto.precio,
                cantidad = producto.cantidad,
                imagen_comida = producto.imagen_comida

            };
            return View(productoViewModel);
        }

        [HttpPost]
        public ActionResult Edit(ProductoViewModel productoViewModel)
        {
            ProductoDALImpl productoDAL = new ProductoDALImpl();
            string mensaje = "";
            try
            {
                mensaje = "Modificado con exito";
                Producto producto = new Producto()
                {
                    id_comida = productoViewModel.id_comida,
                    nombre = productoViewModel.nombre,
                    precio = productoViewModel.precio,
                    cantidad = productoViewModel.cantidad,
                    imagen_comida = productoViewModel.imagen_comida

                };


                productoDAL.UpdateProducto(producto);
                
            }
            catch (Exception ex)
            {
                mensaje = ex.ToString();
            }
            TempData["mensaje"] = mensaje;
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            ProductoDALImpl productoDAL = new ProductoDALImpl();
            string mensaje = "";
            try
            {
                mensaje = "Eliminado con exito";


                productoDAL.DeleteProducto(id);
               
            }
            catch (Exception ex)
            {
                mensaje = ex.ToString();
            }
            TempData["mensaje"] = mensaje;
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            ProductoDALImpl productoDAL = new ProductoDALImpl(); 
            ProductoViewModel productoViewModel;
            Producto producto;


            producto = productoDAL.GetProductoById(id);
            
            productoViewModel = new ProductoViewModel()
            {
                id_comida = producto.id_comida,
                nombre = producto.nombre,
                precio = producto.precio,
                cantidad = producto.cantidad
            };
            return View(productoViewModel);
        }

        [HttpPost]
        public JsonResult Datos_Usuario(Users user)
        {
            Session["Usuario_productos"] = user;

            if (user != null)
                return Json("'Success':'true'" + user);
            else
                return Json(String.Format("'Success':'false','Error':'Ha habido un error al mapear los datos.'"));
        }

        [HttpPost]
        public JsonResult Compra_Final(ProductoViewModel producto)
        {
            

            return Json("Exito");
        }

        public ActionResult About()
        {


            return Redirect("Index");
        }
    }
}
  
