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
    public class ProyeccionesController : Controller
    {
        // GET: Peliculas
        public ActionResult Index()
        {
            List<Proyeccione> proyecciones;
           
            Pelicula pelicula;
            using (UnidadDeTrabajo<Proyeccione> unidad = new UnidadDeTrabajo<Proyeccione>(new BDContext()))
            {
                proyecciones = unidad.genericDAL.GetAll().ToList();
            }


            List<ProyeccionesViewModel> proyeccionesVM = new List<ProyeccionesViewModel>();

            ProyeccionesViewModel proyeccionesViewModel;
            foreach (var item in proyecciones)
            {
                using (UnidadDeTrabajo<Pelicula> unidad = new UnidadDeTrabajo<Pelicula>(new BDContext()))
                {
                    pelicula = unidad.genericDAL.Get(item.id_pelicula);
                }
                proyeccionesViewModel = new ProyeccionesViewModel
                {
                    id_formato = item.id_formato,
                    hora = item.hora,
                    id_pelicula = item.id_pelicula,
                    id_proyeccion = item.id_proyeccion,
                    id_sala = item.id_sala,
                    Pelicula = pelicula
                };
                proyeccionesVM.Add(proyeccionesViewModel);
            }
            return View(proyeccionesVM);
        }

        public ActionResult Detalles(int id)
        {
            IAsientoDAL asientoDAL = new AsientoDALImpl();
            Proyeccione proyeccione;
            Sala sala;
            Pelicula pelicula;
            Clasificacion clasificacion;
            Formato formato;
            List<Asiento> reservados;
            using (UnidadDeTrabajo<Proyeccione> unidad = new UnidadDeTrabajo<Proyeccione>(new BDContext()))
            {
                proyeccione = unidad.genericDAL.Get(id);

            }
            using (UnidadDeTrabajo<Sala> unidad = new UnidadDeTrabajo<Sala>(new BDContext()))
            {
                sala = unidad.genericDAL.Get(proyeccione.id_sala);

            }

            using (UnidadDeTrabajo<Pelicula> unidad = new UnidadDeTrabajo<Pelicula>(new BDContext()))
            {
                pelicula = unidad.genericDAL.Get(proyeccione.id_pelicula);

            }
            using (UnidadDeTrabajo<Clasificacion> unidad = new UnidadDeTrabajo<Clasificacion>(new BDContext()))
            {
                clasificacion = unidad.genericDAL.Get(pelicula.id_clasifacion);

            }
            using (UnidadDeTrabajo<Formato> unidad = new UnidadDeTrabajo<Formato>(new BDContext()))
            {
                formato = unidad.genericDAL.Get(proyeccione.id_formato);

            }
            using (UnidadDeTrabajo<Formato> unidad = new UnidadDeTrabajo<Formato>(new BDContext()))
            {
                reservados = asientoDAL.GetAsientosId(proyeccione.id_sala);
            }
            ProyeccionesViewModel proyeccionesViewModel;


            proyeccionesViewModel = new ProyeccionesViewModel
            {
                id_formato = proyeccione.id_formato,
                id_pelicula = proyeccione.id_pelicula,
                hora = proyeccione.hora,
                id_proyeccion = proyeccione.id_proyeccion,
                id_sala = proyeccione.id_sala,
                Sala = sala,
                Pelicula = pelicula,
                Clasificacion = clasificacion,
                Formato = formato,
                asientos = reservados


        };

            return View(proyeccionesViewModel);
        }


        [HttpPost]
        public JsonResult Entradas(CompraViewModel data)
        {
            
           
            Session["Entradas"] = data;
            
            if (data!= null)
                return Json("'Success':'true'"+data);
            else
                return Json(String.Format("'Success':'false','Error':'Ha habido un error al mapear los datos.'"));
        }

        public JsonResult ConsultaReservas(string[] data)
        {
            
            if (data != null)
            {
                int data1 = int.Parse(data[0]);
                List<AsientoViewModel> asientos_ocupados= new List<AsientoViewModel>();
                AsientoViewModel asiento;
                List<Asiento> lista;
                using (BDContext context = new BDContext())
                {
                    lista = (from c in context.Asientoes
                             where c.id_sala == data1
                             select c).ToList();

                }
                foreach (var item in lista)
                {
                    asiento = new AsientoViewModel {

                    id_asiento = item.id_asiento,
                    id_sala = item.id_sala,
                    numero_asiento = item.numero_asiento,
                    estado = item.estado
                };
                    
                    asientos_ocupados.Add(asiento);
                }
               
                return Json(asientos_ocupados);
            }
            else 
                return Json(String.Format("'Success':'false','Error':'Ha habido un error al mapear los datos.'"));
        }

        public ActionResult Compra() {

            UserViewModel user = new UserViewModel();
           
            return View(user);
        }

        [HttpPost]
        public ActionResult Compra(UserViewModel userViewModel)
        {
            
            CompraViewModel lista= Session["Entradas"] as CompraViewModel;
            
            IUserDAL userDAL = new UserDALImpl();
            User user_temp;
            int id_sala = Convert.ToInt32(lista.sala);
            Asiento asiento = new Asiento();
            Reserva reserva = new Reserva();
            User user = new User()
            {
                
                nombre = userViewModel.nombre,
                apellidos = userViewModel.apellidos,
                Password = userViewModel.Password,
                mail = userViewModel.mail,
                UserName = userViewModel.nombre,
                phone = userViewModel.phone,
                card= userViewModel.card
                
            };

            Session["Usuario_Compra"] = user;

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
                    reserva.id_reserva = unidad.genericDAL.GetAll().Count()+1;
                    unidad.genericDAL.Add(reserva);
                    unidad.Complete();
                }
            }

           
            return RedirectToAction("About", "Proyecciones");

        }

        public ActionResult About()
        {


            return Redirect("~/Reports/Factura.aspx");
        }

    }
    }



