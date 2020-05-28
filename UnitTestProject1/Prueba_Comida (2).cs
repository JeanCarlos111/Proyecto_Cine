using System;
using BackEnd.DAL;
using BackEnd.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class Prueba_Comida
    {
        private UnidadDeTrabajo<Producto> unidad;
        //PRUEBA ADD TABLA COMIDA
        [TestMethod]
        public void TestMethod1()
        {
            using (unidad = new UnidadDeTrabajo<Producto>(new BDContext()))
            {
                // Expression<Func<TablaGeneral, bool>> f2 = (t => t.descripcion == "Prueba");
                // List<TablaGeneral> lista = unidad.genericDAL.Find(f2).ToList();
                //lista.to
                Producto comida = new Producto
                {
                    id_comida=10,
                    nombre="prueba",
                    precio="2510",
                    cantidad="1",
                    
                };
                unidad.genericDAL.Add(comida);
                unidad.Complete();
            }
        }
        //PRUEBA DELETE TABLA COMIDA
        [TestMethod]
        public void TestMethod2()
        {
            using (unidad = new UnidadDeTrabajo<Producto>(new BDContext()))
            {
                // Expression<Func<TablaGeneral, bool>> f2 = (t => t.descripcion == "Prueba");
                // List<TablaGeneral> lista = unidad.genericDAL.Find(f2).ToList();
                //lista.to
                Producto comida = new Producto
                {
                    id_comida = 2,
                    nombre = "pene",
                    precio = "1000",
                    cantidad = "1",
                   
                };
                unidad.genericDAL.Remove(comida);
                unidad.Complete();
            }
        }
        //PRUEBA UPDATE TABLA COMIDA
        [TestMethod]
        public void TestMethod3()
        {
            using (unidad = new UnidadDeTrabajo<Producto>(new BDContext()))
            {
                // Expression<Func<TablaGeneral, bool>> f2 = (t => t.descripcion == "Prueba");
                // List<TablaGeneral> lista = unidad.genericDAL.Find(f2).ToList();
                //lista.to
                Producto comida = new Producto
                {
                    id_comida = 1,
                    nombre = "pizza",
                    precio = "4000",
                    cantidad = "1",
                   
                };
                unidad.genericDAL.Update(comida);
                unidad.Complete();
            }
        }

    }
}
