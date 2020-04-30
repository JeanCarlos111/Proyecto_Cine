using System;
using BackEnd.DAL;
using BackEnd.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class Prueba_Proyecciones
    {
        private UnidadDeTrabajo<Proyeccione> unidad;

        [TestMethod]
        public void TestMethod1()
        {
            using (unidad = new UnidadDeTrabajo<Proyeccione>(new BDContext()))
            {
                // Expression<Func<TablaGeneral, bool>> f2 = (t => t.descripcion == "Prueba");
                // List<TablaGeneral> lista = unidad.genericDAL.Find(f2).ToList();
                //lista.to
                Proyeccione proyecciones = new Proyeccione
                {
                    id_proyeccion = 4,
                    id_sala = 1,
                    id_pelicula = 1,
                    id_formato = 1,
                    hora = "12:40"
                };
                unidad.genericDAL.Add(proyecciones);
                unidad.Complete();
            }
        }
        [TestMethod]
        public void TestMethod2()
        {
            using (unidad = new UnidadDeTrabajo<Proyeccione>(new BDContext()))
            {
                // Expression<Func<TablaGeneral, bool>> f2 = (t => t.descripcion == "Prueba");
                // List<TablaGeneral> lista = unidad.genericDAL.Find(f2).ToList();
                //lista.to
                Proyeccione proyecciones = new Proyeccione
                {
                    id_proyeccion = 2,
                    id_sala = 1,
                    id_pelicula = 1,
                    id_formato = 1,
                    hora = "69:69"
                };
                unidad.genericDAL.Remove(proyecciones);
                unidad.Complete();
            }
        }
        [TestMethod]
        public void TestMethod3()
        {
            using (unidad = new UnidadDeTrabajo<Proyeccione>(new BDContext()))
            {
                // Expression<Func<TablaGeneral, bool>> f2 = (t => t.descripcion == "Prueba");
                // List<TablaGeneral> lista = unidad.genericDAL.Find(f2).ToList();
                //lista.to
                Proyeccione proyecciones = new Proyeccione
                {
                    id_proyeccion = 1,
                    id_sala = 1,
                    id_pelicula = 1,
                    id_formato = 1,
                    hora = "1:30"
                };
                unidad.genericDAL.Update(proyecciones);
                unidad.Complete();
            }
        }

    }
}
