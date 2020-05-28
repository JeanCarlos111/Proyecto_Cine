using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BackEnd.DAL;
using BackEnd.Entities;

namespace UnitTestProject1
{
    [TestClass]
    public class Prueba_Clasificacion
    {
        private UnidadDeTrabajo<Clasificacion> unidad;

        [TestMethod]
        public void Add()
        {
            using (unidad = new UnidadDeTrabajo<Clasificacion>(new BDContext()))
            {
                // Expression<Func<TablaGeneral, bool>> f2 = (t => t.descripcion == "Prueba");
                // List<TablaGeneral> lista = unidad.genericDAL.Find(f2).ToList();
                //lista.to
                Clasificacion clasificacion = new Clasificacion
                {
                    id_clasificacion = 1,
                    tipo_clasificacion = "+18"
                };
                unidad.genericDAL.Add(clasificacion);
                unidad.Complete();
            }
        }

        [TestMethod]
        public void Delete()
        {
            using (unidad = new UnidadDeTrabajo<Clasificacion>(new BDContext()))
            {
                // Expression<Func<TablaGeneral, bool>> f2 = (t => t.descripcion == "Prueba");
                // List<TablaGeneral> lista = unidad.genericDAL.Find(f2).ToList();
                //lista.to
                Clasificacion clasificacion = new Clasificacion
                {
                    id_clasificacion = 1,
                    tipo_clasificacion = "+18"
                };
                unidad.genericDAL.Remove(clasificacion);
                unidad.Complete();
            }
        }

        [TestMethod]
        public void Update()
        {
            using (unidad = new UnidadDeTrabajo<Clasificacion>(new BDContext()))
            {
                // Expression<Func<TablaGeneral, bool>> f2 = (t => t.descripcion == "Prueba");
                // List<TablaGeneral> lista = unidad.genericDAL.Find(f2).ToList();
                //lista.to
                Clasificacion  clasificacion = new Clasificacion
                {
                    id_clasificacion = 1,
                    tipo_clasificacion = "+15"
                };
                unidad.genericDAL.Update(clasificacion);
                unidad.Complete();
            }
        }
    }
}
