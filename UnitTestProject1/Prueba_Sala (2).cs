using System;
using BackEnd.DAL;
using BackEnd.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class Prueba_Sala
    {
        private UnidadDeTrabajo<Sala> unidad;
        [TestMethod]
        public void TestMethod1()
        {
            using (unidad = new UnidadDeTrabajo<Sala>(new BDContext()))
            {
                // Expression<Func<TablaGeneral, bool>> f2 = (t => t.descripcion == "Prueba");
                // List<TablaGeneral> lista = unidad.genericDAL.Find(f2).ToList();
                //lista.to
                Sala sala = new Sala
                {
                    id_sala=1,
                    sala1="1",
                    numero_asiento=1
                };
                unidad.genericDAL.Add(sala);
                unidad.Complete();
            }
        }

        [TestMethod]
        public void TestMethod2()
        {
            using (unidad = new UnidadDeTrabajo<Sala>(new BDContext()))
            {
                // Expression<Func<TablaGeneral, bool>> f2 = (t => t.descripcion == "Prueba");
                // List<TablaGeneral> lista = unidad.genericDAL.Find(f2).ToList();
                //lista.to
                Sala sala = new Sala
                {
                    id_sala = 2,
                    sala1 = "1",
                    numero_asiento = 69
                };
                unidad.genericDAL.Remove(sala);
                unidad.Complete();
            }
        }

        [TestMethod]
        public void TestMethod3()
        {
            using (unidad = new UnidadDeTrabajo<Sala>(new BDContext()))
            {
                // Expression<Func<TablaGeneral, bool>> f2 = (t => t.descripcion == "Prueba");
                // List<TablaGeneral> lista = unidad.genericDAL.Find(f2).ToList();
                //lista.to
                Sala sala = new Sala
                {
                    id_sala = 1,
                    sala1 = "2",
                    numero_asiento = 30
                };
                unidad.genericDAL.Update(sala);
                unidad.Complete();
            }
        }

    }
}
