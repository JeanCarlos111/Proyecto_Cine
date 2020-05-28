using System;
using System.Text;
using System.Collections.Generic;
using BackEnd.Entities;
using BackEnd.DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Web;


namespace UnitTestProject1
{
    /// <summary>
    /// Descripción resumida de AsientosSeleccionados
    /// </summary>
    [TestClass]
    public class Prueba_AsientosSeleccionados
    {

        private UnidadDeTrabajo<Asiento> unidad;
        //PRUEBA ADD TABLA COMIDA
        [TestMethod]
        public void SeleccionarAsientosReservado()
        {
            Asiento asiento_nuevo;
           
            List<Asiento> asientos;


            using (unidad = new UnidadDeTrabajo<Asiento>(new BDContext()))
            {
                asiento_nuevo = new Asiento
                {
                    id_sala = 1,
                    id_asiento = unidad.genericDAL.GetAll().Count() + 1,
                    estado = 1,
                    numero_asiento = "A-1"
                };
                
              
                asientos = unidad.genericDAL.GetAll().ToList();
                foreach (var item in asientos)
                {
                    if (item.numero_asiento == asiento_nuevo.numero_asiento && item.id_sala == asiento_nuevo.id_sala)
                    {
                        Console.WriteLine("Asiento ocupado" + " " + "Por Favor Seleccionar otro");
                    }
                    else
                    {
                        Console.WriteLine("Ingresa con exito");
                    }
                   
                }

            }

        }


    }
}
