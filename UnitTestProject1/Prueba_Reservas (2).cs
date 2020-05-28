using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BackEnd.DAL;
using BackEnd.Entities;

namespace UnitTestProject1
{

    [TestClass]
    public class Prueba_Reservas
    {
        private UnidadDeTrabajo<Reserva> unidad;

        [TestMethod]
        public void TestMethod1()
        {
            using (unidad = new UnidadDeTrabajo<Reserva>(new BDContext()))
            {
                // Expression<Func<TablaGeneral, bool>> f2 = (t => t.descripcion == "Prueba");
                // List<TablaGeneral> lista = unidad.genericDAL.Find(f2).ToList();
                //lista.to
                Reserva reservas = new Reserva
                {
                    id_asiento = 1,
                    id_cliente = 1,
                    id_reserva = 4,
                    estado_reserva = "Activo"
                };
                unidad.genericDAL.Add(reservas);
                unidad.Complete();
            }
        }
        [TestMethod]
        public void TestMethod2()
        {
            using (unidad = new UnidadDeTrabajo<Reserva>(new BDContext()))
            {
                // Expression<Func<TablaGeneral, bool>> f2 = (t => t.descripcion == "Prueba");
                // List<TablaGeneral> lista = unidad.genericDAL.Find(f2).ToList();
                //lista.to
                Reserva reservas = new Reserva
                {
                    id_asiento = 1,
                    id_cliente = 1,
                    id_reserva = 2,
                    estado_reserva = "Activo"
                };
                unidad.genericDAL.Remove(reservas);
                unidad.Complete();
            }
        }
        [TestMethod]
        public void TestMethod3()
        {
            using (unidad = new UnidadDeTrabajo<Reserva>(new BDContext()))
            {
                // Expression<Func<TablaGeneral, bool>> f2 = (t => t.descripcion == "Prueba");
                // List<TablaGeneral> lista = unidad.genericDAL.Find(f2).ToList();
                //lista.to
                Reserva reservas = new Reserva
                {
                    id_asiento = 1,
                    id_cliente = 1,
                    id_reserva = 1,
                    estado_reserva = "No Aceptado"
                };
                unidad.genericDAL.Update(reservas);
                unidad.Complete();
            }
        }
        }
    }

