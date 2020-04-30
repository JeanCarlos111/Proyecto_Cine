using System;
using BackEnd.DAL;
using BackEnd.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class Prueba_Formato
    {
        private UnidadDeTrabajo<Formato> unidad;

        [TestMethod]
        public void TestMethod1()
        {
               using (unidad = new UnidadDeTrabajo<Formato>(new BDContext()))
            {
                // Expression<Func<TablaGeneral, bool>> f2 = (t => t.descripcion == "Prueba");
                // List<TablaGeneral> lista = unidad.genericDAL.Find(f2).ToList();
                //lista.to
               Formato formato = new  Formato
                {
                     id_formato=7,
                     formato1="PRUEBA2"
                };

                unidad.genericDAL.Add(formato);
                unidad.Complete();
            }
        }

        [TestMethod]
        public void TestMethod2()
        {
            using (unidad = new UnidadDeTrabajo<Formato>(new BDContext()))
            {
                // Expression<Func<TablaGeneral, bool>> f2 = (t => t.descripcion == "Prueba");
                // List<TablaGeneral> lista = unidad.genericDAL.Find(f2).ToList();
                //lista.to
                Formato formato = new Formato
                {
                    id_formato = 7,
                    formato1 = "PRUEBA2"
                };

                unidad.genericDAL.Remove(formato);
                unidad.Complete();
            }
        }

        [TestMethod]
        public void TestMethod3()
        {
            using (unidad = new UnidadDeTrabajo<Formato>(new BDContext()))
            {
                // Expression<Func<TablaGeneral, bool>> f2 = (t => t.descripcion == "Prueba");
                // List<TablaGeneral> lista = unidad.genericDAL.Find(f2).ToList();
                //lista.to
                Formato formato = new Formato
                {
                    id_formato = 6,
                    formato1 = "PRUEBA"
                };

                unidad.genericDAL.Update(formato);
                unidad.Complete();
            }
        }
    }



}

