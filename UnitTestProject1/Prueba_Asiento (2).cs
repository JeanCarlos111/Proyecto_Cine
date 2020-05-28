using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BackEnd.DAL;
using BackEnd.Entities;

namespace UnitTestProject1
{
 
    [TestClass]
    public class Prueba_Asiento
    {
        private UnidadDeTrabajo<Asiento> unidad;

        [TestMethod]
        public void TestMethod1()
        {
            using (unidad = new UnidadDeTrabajo<Asiento>(new BDContext()))
            {
                // Expression<Func<TablaGeneral, bool>> f2 = (t => t.descripcion == "Prueba");
                // List<TablaGeneral> lista = unidad.genericDAL.Find(f2).ToList();
                //lista.to
                Asiento asiento = new Asiento
                {
                    id_asiento = 3,
                    id_sala = 1
                };
                unidad.genericDAL.Add(asiento);
                unidad.Complete();
            }
        }
        [TestMethod]
        public void TestMethod2()
        {
            using (unidad = new UnidadDeTrabajo<Asiento>(new BDContext()))
            {
                // Expression<Func<TablaGeneral, bool>> f2 = (t => t.descripcion == "Prueba");
                // List<TablaGeneral> lista = unidad.genericDAL.Find(f2).ToList();
                //lista.to
                Asiento asiento = new Asiento
                {
                    id_asiento = 3,
                    id_sala = 1
                };
                unidad.genericDAL.Remove(asiento);
                unidad.Complete();
            }
        }
        [TestMethod]
        public void TestMethod3()
        {
            using (unidad = new UnidadDeTrabajo<Asiento>(new BDContext()))
            {
                // Expression<Func<TablaGeneral, bool>> f2 = (t => t.descripcion == "Prueba");
                // List<TablaGeneral> lista = unidad.genericDAL.Find(f2).ToList();
                //lista.to
                Asiento asiento = new Asiento
                {
                    id_asiento = 3,
                    id_sala = 1
                };
                unidad.genericDAL.Update(asiento);
                unidad.Complete();
            }
        }
    }
}
