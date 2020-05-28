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
    public class PeliculasController : Controller
    {
        // GET: Peliculas
        public ActionResult Index()
        {
            PeliculaViewModel peliculaViewModel;
            string mensaje = "";
            if (TempData["mensaje"] != null)
            {
                mensaje = TempData["mensaje"].ToString();
            }

            List<Pelicula> pelicula;
            PeliculaDALImpl peliculaDAL = new PeliculaDALImpl();

            pelicula = peliculaDAL.GetPeliculas();

            List<PeliculaViewModel> peliculaVM = new List<PeliculaViewModel>();

            PeliculaViewModel PeliculaViewModel;
            foreach (var item in pelicula)
            {
                peliculaViewModel = new PeliculaViewModel
                {
                     id_pelicula = item.id_pelicula,
                     id_clasifacion = item.id_clasifacion,
                     id_formato = item.id_formato,
                     id_genero = item.id_genero,
                     nombre_pelicula = item.nombre_pelicula,
                     imagen_pelicula = item.imagen_pelicula
                };
                peliculaVM.Add(peliculaViewModel);
            }
            return View(peliculaVM);
        }

        public ActionResult Create()
        {
            PeliculaViewModel pelicula = new PeliculaViewModel();
            return View(pelicula);
        }

        [HttpPost]
        public ActionResult Create(PeliculaViewModel peliculaViewModel)
        {
            PeliculaDALImpl peliculaDAL = new PeliculaDALImpl();
            string mensaje = "";
            try
            {
                mensaje = "Agregado con exito";
                Pelicula pelicula = new Pelicula()
                {
                    id_pelicula = peliculaDAL.GetPeliculas().Count + 1, 
                    id_clasifacion = peliculaViewModel.id_clasifacion,
                    id_formato = peliculaViewModel.id_formato,
                    id_genero= peliculaViewModel.id_genero,
                    nombre_pelicula = peliculaViewModel.nombre_pelicula,
                    imagen_pelicula = peliculaViewModel.imagen_pelicula,
                    duracion_pelicula = peliculaViewModel.duracion_pelicula
                };

                peliculaDAL.AddPelicula(pelicula);
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
            PeliculaDALImpl peliculaDAL = new PeliculaDALImpl();

            PeliculaViewModel peliculaViewModel;

            Pelicula pelicula;

            pelicula = peliculaDAL.GetPeliculaById(id);


            peliculaViewModel = new PeliculaViewModel()
            {
                
                id_pelicula = pelicula.id_pelicula,
                id_clasifacion = pelicula.id_clasifacion,
                id_formato = pelicula.id_formato,
                id_genero = pelicula.id_genero,
                nombre_pelicula = pelicula.nombre_pelicula,
                imagen_pelicula = pelicula.imagen_pelicula,
                duracion_pelicula = pelicula.duracion_pelicula

            };
            return View(peliculaViewModel);
        }

        public JsonResult ConsultaFormato(string[] data)
        {
            FormatoDALImpl formatoDAL = new FormatoDALImpl();
            Formato formato_temporal;

            FormatoViewModel formatoViewModel;
            if (data != null)
            {
                int data1 = int.Parse(data[0]);

               formato_temporal = formatoDAL.GetFormatoById(data1);


                formatoViewModel = new FormatoViewModel
                {

                     id_formato = formato_temporal.id_formato,
                     formato1 = formato_temporal.formato1



                };

                return Json(formatoViewModel);
            }
            else
                return Json(String.Format("'Success':'false','Error':'Ha habido un error al mapear los datos.'"));
        }

        public JsonResult ConsultaClasificacion(string[] data)
        {
            ClasificacionDALImpl clasificacionDAL = new ClasificacionDALImpl();
            Clasificacion clasificacion_temporal;

            ClasificacionViewModel clasificacionViewModel;
            if (data != null)
            {
                int data1 = int.Parse(data[0]);

                clasificacion_temporal = clasificacionDAL.GetClasificacionById(data1);


                clasificacionViewModel = new ClasificacionViewModel
                {

                     id_clasificacion = clasificacion_temporal.id_clasificacion,
                     tipo_clasificacion = clasificacion_temporal.tipo_clasificacion



                };

                return Json(clasificacionViewModel);
            }
            else
                return Json(String.Format("'Success':'false','Error':'Ha habido un error al mapear los datos.'"));
        }

        public JsonResult ConsultaGenero(string[] data)
        {
            GeneroDALImpl generoDAL = new GeneroDALImpl();
            Genero genero_temporal;

            GeneroViewModel generoViewModel;
            if (data != null)
            {
                int data1 = int.Parse(data[0]);

                genero_temporal = generoDAL.GetGeneroById(data1);


                generoViewModel = new GeneroViewModel
                {

                    
                     id_genero = genero_temporal.id_genero,
                     genero1 = genero_temporal.genero1


                };

                return Json(generoViewModel);
            }
            else
                return Json(String.Format("'Success':'false','Error':'Ha habido un error al mapear los datos.'"));
        }

        [HttpPost]
        public ActionResult Edit(PeliculaViewModel peliculaViewModel)
        {
            PeliculaDALImpl peliculaDAL = new PeliculaDALImpl();
            string mensaje = "";
            try
            {
                mensaje = "Modificado con exito";
                Pelicula pelicula = new Pelicula()
                {
                    id_pelicula= peliculaViewModel.id_pelicula,
                    id_clasifacion = peliculaViewModel.id_clasifacion,
                    id_formato = peliculaViewModel.id_formato,
                    id_genero = peliculaViewModel.id_genero,
                    nombre_pelicula = peliculaViewModel.nombre_pelicula,
                    imagen_pelicula = peliculaViewModel.imagen_pelicula,
                    duracion_pelicula = peliculaViewModel.duracion_pelicula

                };

                peliculaDAL.UpdatePelicula(pelicula);
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
            PeliculaDALImpl peliculaDAL = new PeliculaDALImpl();
            string mensaje = "";
            try
            {
                mensaje = "Eliminado con exito";
                Pelicula pelicula;

                pelicula = peliculaDAL.GetPeliculaById(id);
                peliculaDAL.DeletePelicula(pelicula.id_pelicula);


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
    
