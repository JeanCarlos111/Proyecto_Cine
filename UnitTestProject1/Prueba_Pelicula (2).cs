using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BackEnd.Entities;
using BackEnd.DAL;

namespace UnitTestProject1
{
    [TestClass]
    public class Prueba_Pelicula
    {
        private UnidadDeTrabajo<Pelicula> unidad;

        [TestMethod]
        public void Add()
        {
            using (unidad = new UnidadDeTrabajo<Pelicula>(new BDContext()))
            {
                // Expression<Func<TablaGeneral, bool>> f2 = (t => t.descripcion == "Prueba");
                // List<TablaGeneral> lista = unidad.genericDAL.Find(f2).ToList();
                //lista.to
                Pelicula pelicula = new Pelicula
                {
                    id_pelicula = 1,
                    id_clasifacion = 18,
                    nombre_pelicula = "Avengers",
                    duracion_pelicula = "2 horas",
                    id_genero = 1
                };
                unidad.genericDAL.Add(pelicula);
                unidad.Complete();
            }
        }

        [TestMethod]
        public void Delete()
        {
            using (unidad = new UnidadDeTrabajo<Pelicula>(new BDContext()))
            {
                // Expression<Func<TablaGeneral, bool>> f2 = (t => t.descripcion == "Prueba");
                // List<TablaGeneral> lista = unidad.genericDAL.Find(f2).ToList();
                //lista.to
                Pelicula pelicula = new Pelicula
                {
                    id_pelicula = 1,
                    id_clasifacion = 18,
                    nombre_pelicula = "Avengers",
                    duracion_pelicula = "2 horas",
                    id_genero = 1
                };
                unidad.genericDAL.Remove(pelicula);
                unidad.Complete();
            }
        }

        [TestMethod]
        public void Update()
        {
            using (unidad = new UnidadDeTrabajo<Pelicula>(new BDContext()))
            {
                // Expression<Func<TablaGeneral, bool>> f2 = (t => t.descripcion == "Prueba");
                // List<TablaGeneral> lista = unidad.genericDAL.Find(f2).ToList();
                //lista.to
                Pelicula pelicula = new Pelicula
                {
                    id_pelicula = 1,
                    id_clasifacion = 18,
                    nombre_pelicula = "Batman",
                    duracion_pelicula = "1 hora",
                    id_genero = 1
                };
                unidad.genericDAL.Update(pelicula);
                unidad.Complete();
            }
        }
    }
}
