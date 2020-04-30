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
    [Authorize(Roles = "Administrador,Consulta")]
    public class ComidasController : Controller
    {
        // GET: Comidas
        public ActionResult Index()
        {

            List<Producto> proyecciones;

            using (UnidadDeTrabajo<Producto> unidad = new UnidadDeTrabajo<Producto>(new BDContext()))
            {
                proyecciones = unidad.genericDAL.GetAll().ToList();
            }


            List<ComidasViewModel> proyeccionesVM = new List<ComidasViewModel>();

            ComidasViewModel proyeccionesViewModel;
            foreach (var item in proyecciones)
            {

                proyeccionesViewModel = new ComidasViewModel
                {
                    id_comida = item.id_comida,
                    cantidad = item.cantidad,
                    nombre = item.nombre,
                    precio = item.precio,
                    imagen_comida = item.imagen_comida
                };
                proyeccionesVM.Add(proyeccionesViewModel);
            }



            return View(proyeccionesVM);
        }

        public ActionResult Create()
        {
            ComidasViewModel comidas = new ComidasViewModel();
            return View(comidas);
        }
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public ActionResult Create(ComidasViewModel comidasViewModel)
        {
            string mensaje = "";
            try
            {
                mensaje = "Agregado con exito";


                Producto produc = new Producto()
                {

                    nombre = comidasViewModel.nombre,
                    precio = comidasViewModel.precio,
                    cantidad = comidasViewModel.cantidad,
                    imagen_comida = comidasViewModel.imagen_comida
                };

                using (UnidadDeTrabajo<Producto> unidad = new UnidadDeTrabajo<Producto>(new BDContext()))
                {
                    produc.id_comida = unidad.genericDAL.GetAll().Count() + 1;

                    unidad.genericDAL.Add(produc);
                    unidad.Complete();
                }
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
            ComidasViewModel comidasViewModel;
            Producto producto;
            using (UnidadDeTrabajo<Producto> unidad = new UnidadDeTrabajo<Producto>(new BDContext()))
            {
                producto = unidad.genericDAL.Get(id);
            }
            comidasViewModel = new ComidasViewModel()
            {
                id_comida = producto.id_comida,
                nombre = producto.nombre,
                precio = producto.precio,
                cantidad = producto.cantidad,
                imagen_comida = producto.imagen_comida

            };
            return View(comidasViewModel);
        }

        [HttpPost]
        public ActionResult Edit(ComidasViewModel comidasViewModel)
        {
            string mensaje = "";
            try
            {
                mensaje = "Modificado con exito";
                Producto producto = new Producto()
                {
                    id_comida = comidasViewModel.id_comida,
                    nombre = comidasViewModel.nombre,
                    precio = comidasViewModel.precio,
                    cantidad = comidasViewModel.cantidad,
                    imagen_comida = comidasViewModel.imagen_comida

                };

                using (UnidadDeTrabajo<Producto> unidad = new UnidadDeTrabajo<Producto>(new BDContext()))
                {
                    unidad.genericDAL.Update(producto);
                    unidad.Complete();
                }
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
            string mensaje = "";
            try
            {
                mensaje = "Eliminado con exito";
                Producto producto;
                using (UnidadDeTrabajo<Producto> unidad = new UnidadDeTrabajo<Producto>(new BDContext()))
                {
                    producto = unidad.genericDAL.Get(id);
                    unidad.genericDAL.Remove(producto);
                    unidad.Complete();
                }
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
            ComidasViewModel comidasViewModel;
            Producto producto;

            using (UnidadDeTrabajo<Producto> unidad = new UnidadDeTrabajo<Producto>(new BDContext()))
            {
                producto = unidad.genericDAL.Get(id);
            }
            comidasViewModel = new ComidasViewModel()
            {
                id_comida = producto.id_comida,
                nombre = producto.nombre,
                precio = producto.precio,
                cantidad = producto.cantidad
            };
            return View(comidasViewModel);
        }

        [HttpPost]
        public JsonResult Datos_Usuario(User user)
        {
            Session["Usuario_Compra"] = user;

            if (user != null)
                return Json("'Success':'true'" + user);
            else
                return Json(String.Format("'Success':'false','Error':'Ha habido un error al mapear los datos.'"));
        }

        [HttpPost]
        public JsonResult Compra_Final(ProductoViewModel producto)
        {
            IUserDAL userDAL = new UserDALImpl();
            CompraViewModel lista = Session["Entradas"] as CompraViewModel;
            User userViewModel = Session["Usuario_Compra"] as User;
            Session["Orden_Comida"] = producto;
            producto = Session["Orden_Comida"] as ProductoViewModel;
            int id_sala = Convert.ToInt32(lista.sala);
            Asiento asiento = new Asiento();
            Reserva reserva = new Reserva();
            User user_temp;
            User user = new User()

            {
                nombre = userViewModel.nombre,
                apellidos = userViewModel.apellidos,
                Password = userViewModel.Password,
                mail = userViewModel.mail,
                UserName = userViewModel.nombre,
                phone = userViewModel.phone,
                card = userViewModel.card

            };



            using (UnidadDeTrabajo<User> unidad = new UnidadDeTrabajo<User>(new BDContext()))
            {

                unidad.genericDAL.Add(user);
                unidad.Complete();
                user_temp = userDAL.getUser(user.nombre);
                reserva.id_cliente = user_temp.UserId;

            }

            foreach (var item in lista.numero_asiento)
            {
                asiento.id_sala = id_sala;
                asiento.numero_asiento = item;
                asiento.estado = 1;
                using (UnidadDeTrabajo<Asiento> unidad = new UnidadDeTrabajo<Asiento>(new BDContext()))
                {
                    asiento.id_asiento = unidad.genericDAL.GetAll().Count() + 1;
                    unidad.genericDAL.Add(asiento);
                    unidad.Complete();
                    reserva.id_asiento = unidad.genericDAL.GetAll().Count();
                }

                using (UnidadDeTrabajo<Reserva> unidad = new UnidadDeTrabajo<Reserva>(new BDContext()))
                {
                    reserva.id_reserva = unidad.genericDAL.GetAll().Count() + 1;
                    unidad.genericDAL.Add(reserva);
                    unidad.Complete();
                }
            }

            return Json("Exito");
        }

        public ActionResult About()
        {


            return Redirect("~/Reports/Factura.aspx");
        }
    }
}
  
