using BackEnd.DAL;
using BackEnd.DAL.Usuarios;
using BackEnd.Entities;
using FrontEnd.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Configuration;
using System.Net.Mail;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;

namespace FrontEnd.Controllers
{
    
    public class ProyeccionesController : Controller
    {
        // GET: Peliculas
        public ActionResult Index()
        {
            


                ProyeccionDALImpl proyeccionDAL = new ProyeccionDALImpl();

                PeliculaDALImpl peliculaDAL = new PeliculaDALImpl();

                List<ProyeccionesViewModel> proyeccionesVM = new List<ProyeccionesViewModel>();

                List<Proyeccion> proyecciones;

                Pelicula pelicula;

                proyecciones = proyeccionDAL.GetProyecciones();





                ProyeccionesViewModel proyeccionesViewModel;
                foreach (var item in proyecciones)
                {

                    pelicula = peliculaDAL.GetPeliculaById((int)item.id_pelicula);

                    proyeccionesViewModel = new ProyeccionesViewModel
                    {
                        
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
            ProyeccionDALImpl proyeccionDAL = new ProyeccionDALImpl();
            PeliculaDALImpl peliculaDAL = new PeliculaDALImpl();
            ClasificacionDALImpl clasificacionDAL = new ClasificacionDALImpl();
            FormatoDALImpl formatoDAL = new FormatoDALImpl();
            GeneroDALImpl generoDAL = new GeneroDALImpl();
            SalaDALImpl salaDAL = new SalaDALImpl();

           
            ProyeccionesViewModel proyeccionesViewModel;
            Sala sala;
            Pelicula pelicula;
            Proyeccion proyeccion;
            Clasificacion clasificacion;
            Formato formato;

            pelicula = peliculaDAL.GetPeliculaById((int)id);

            proyeccion = proyeccionDAL.GetProyeccionesById(id);

            sala = salaDAL.GetSalaById( (int) proyeccion.id_sala);

            clasificacion = clasificacionDAL.GetClasificacionById(pelicula.id_clasifacion);

            formato = formatoDAL.GetFormatoById( (int) pelicula.id_formato);

            proyeccionesViewModel = new ProyeccionesViewModel
            {
                
                id_pelicula = proyeccion.id_pelicula,
                hora = proyeccion.hora,
                id_proyeccion = proyeccion.id_proyeccion,
                id_sala = proyeccion.id_sala,
                Sala = sala,
                Pelicula = pelicula,
                Clasificacion = clasificacion,
                Formato = formato,
                Asiento = null


        };

            return View(proyeccionesViewModel);
        }


        [HttpPost]
        public JsonResult Entradas(CompraViewModel datos)
        {
            
           
            Session["Entradas"] = datos;
            
            if (datos != null)
                return Json("'Success':'true'"+datos);
            else
                return Json(String.Format("'Success':'false','Error':'Ha habido un error al mapear los datos.'"));
        }

       public JsonResult ConsultaReservas(string[] data)
        {
            AsientoDALImpl asientoDAL = new AsientoDALImpl();
            AsientoViewModel asiento_temporal;
            List<AsientoViewModel> asientos_ocupados = new List<AsientoViewModel>();
            if (data != null)
            {
                int data1 = int.Parse(data[0]);
                
                List<Asiento> asientos = asientoDAL.GetAsientosBySala(data1);

                foreach (var item in asientos)
                {
                    asiento_temporal = new AsientoViewModel
                    {

                        id_asiento = item.id_asiento,
                        numero_asiento = item.numero_asiento,
                        estado = item.estado
                    };

                    asientos_ocupados.Add(asiento_temporal);
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


            CompraViewModel lista = Session["Entradas"] as CompraViewModel;

            UsuarioDALImpl userDAL = new UsuarioDALImpl();
            AsientoDALImpl asientoDAL = new AsientoDALImpl();
            CompraDALImpl compraDAL = new CompraDALImpl();
            IntermediaDALImpl intermediaDAL = new IntermediaDALImpl();
            Intermedia intermedia;
            Users user_temp;
            Asiento asiento_temp;
            int id_sala = Convert.ToInt32(lista.sala);
            Asiento asiento = new Asiento();
            Compra compra = new Compra();
            
            Users user = new Users()
            {

                nombre = userViewModel.nombre,
                apellidos = userViewModel.apellidos,
                Password = userViewModel.Contrasena,
                mail = userViewModel.mail,
                UserName = userViewModel.nombre,
                phone = userViewModel.phone,
                tarjeta = userViewModel.tarjeta

            };

            Session["Usuario_Compra"] = user;

            

                userDAL.AddUsuario(user);
                user_temp = userDAL.GetUsuario(user.nombre);
                compra.id_cliente = user_temp.UserId;
                compra.id_compra = compraDAL.GetCompras().Count() + 1;


            foreach (var item in lista.numero_asiento)
            {
                asiento.numero_asiento = item;
                asiento.estado = 1;
                asientoDAL.AddAsiento(asiento);

                asiento_temp = asientoDAL.GetAsiento(asiento.numero_asiento);
                intermedia = new Intermedia()
                {
                     id_asiento = asiento_temp.id_asiento,
                     id_intermedia = intermediaDAL.GetIntermedios().Count+1 , 
                     id_sala = id_sala
                };
                intermediaDAL.AddIntermedia(intermedia);
                compra.numeros_asientos += item +',' ;
                
                
               
            }
            compra.id_compra = compraDAL.GetCompras().Count + 1;
            compra.precio_boletos =Convert.ToString( Convert.ToInt32(lista.precio_entradas) * Convert.ToInt32(lista.cantidad_asientos));
            compra.precio_productos = "2400";
            compraDAL.AddCompra(compra);


            System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();
            mmsg.To.Add(user.mail);
            mmsg.Subject = "Boletos Compra";
            mmsg.SubjectEncoding = System.Text.Encoding.UTF8;

            foreach (var item in lista.numero_asiento)
            {

                mmsg.Body += item +",";
            }
            mmsg.Body += "Gracias por su compra" +user.nombre;
            mmsg.BodyEncoding = System.Text.Encoding.UTF8;
            mmsg.IsBodyHtml = true;
            mmsg.From = new System.Net.Mail.MailAddress("jeank2597@gmail.com");

            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();

           
            client.UseDefaultCredentials = false;
            client.Port = 587;
            client.Credentials = new System.Net.NetworkCredential("jeank2597@gmail.com", "1234567CARLOS..");
            client.EnableSsl =true;
            

            client.Host = "smtp.gmail.com";







            try
            {
                client.Send(mmsg);
                
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }

            



            return RedirectToAction("About", "Proyecciones");

        }

        public ActionResult About()
        {

           

            return RedirectToAction("Index", "Proyecciones");
        }

        public ActionResult Create()
        {
            ProyeccionesViewModel proyecciones = new ProyeccionesViewModel();
            return View(proyecciones);

            
        }

        [HttpPost]
        public ActionResult Create(ProyeccionesViewModel proyeccionesViewModel)
        {
            ProyeccionDALImpl proyeccionDAL = new ProyeccionDALImpl();
            string mensaje = "";
            try
            {
                mensaje = "Agregado con exito";
                Proyeccion proyeccion = new Proyeccion()
                {
                    id_proyeccion = proyeccionDAL.GetProyecciones().Count + 1,
                    id_pelicula = (int)proyeccionesViewModel.id_pelicula,
                    id_sala = (int)proyeccionesViewModel.id_sala,
                    hora = proyeccionesViewModel.hora

                };

                proyeccionDAL.AddProyeccion(proyeccion);
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
            ProyeccionDALImpl proyeccionDAL = new ProyeccionDALImpl();

            ProyeccionesViewModel proyeccionesViewModel;

            Proyeccion proyeccion;

            proyeccion = proyeccionDAL.GetProyeccionesById(id);


            proyeccionesViewModel = new ProyeccionesViewModel()
            {
                 id_proyeccion= proyeccion.id_proyeccion,
                 id_pelicula = proyeccion.id_pelicula,
                 id_sala = proyeccion.id_sala,
                 hora = proyeccion.hora
 
            };

            return View(proyeccionesViewModel);
        }

        [HttpPost]
        public ActionResult Edit(ProyeccionesViewModel proyeccionesViewModel)
        {
            ProyeccionDALImpl proyeccionDAL = new ProyeccionDALImpl();
            string mensaje = "";
            try
            {
                mensaje = "Modificado con exito";
                Proyeccion proyeccion = new Proyeccion()
                {
                     id_pelicula = (int) proyeccionesViewModel.id_pelicula,
                      id_sala = (int) proyeccionesViewModel.id_sala,
                       hora = proyeccionesViewModel.hora

                };

                proyeccionDAL.UpdateProyeccion(proyeccion);
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
            ProyeccionDALImpl proyeccionDAL = new ProyeccionDALImpl();
            string mensaje = "";
            try
            {
                mensaje = "Eliminado con exito";
                Proyeccion proyeccion;

                proyeccion = proyeccionDAL.GetProyeccionesById(id); ;
                proyeccionDAL.DeleteProyeccion(proyeccion.id_proyeccion);


            }
            catch (Exception ex)
            {
                mensaje = ex.ToString();
            }
            TempData["mensaje"] = mensaje;
            return RedirectToAction("Index");

           
        }

    }


}



