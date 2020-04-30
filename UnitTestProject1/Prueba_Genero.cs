using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BackEnd.Entities;
using BackEnd.DAL;

namespace UnitTestProject1
{
    [TestClass]
    public class Prueba_Genero
    {
        private UnidadDeTrabajo<Genero> unidad;

        [TestMethod]
        public void Add()
        {
            using (unidad = new UnidadDeTrabajo<Genero>(new BDContext()))
            {
                // Expression<Func<TablaGeneral, bool>> f2 = (t => t.descripcion == "Prueba");
                // List<TablaGeneral> lista = unidad.genericDAL.Find(f2).ToList();
                //lista.to
                Genero genero = new Genero
                {
                    id_genero = 1,
                    genero1 = "Prueba"
                };
                unidad.genericDAL.Add(genero);
                unidad.Complete();
            }
        }

        [TestMethod]
        public void Delete()
        {
            using (unidad = new UnidadDeTrabajo<Genero>(new BDContext()))
            {
                // Expression<Func<TablaGeneral, bool>> f2 = (t => t.descripcion == "Prueba");
                // List<TablaGeneral> lista = unidad.genericDAL.Find(f2).ToList();
                //lista.to
                Genero genero = new Genero
                {
                    id_genero = 1,
                    genero1 = "Prueba"
                };
                unidad.genericDAL.Remove(genero);
                unidad.Complete();
            }
        }

        [TestMethod]
        public void Update()
        {
            using (unidad = new UnidadDeTrabajo<Genero>(new BDContext()))
            {
                // Expression<Func<TablaGeneral, bool>> f2 = (t => t.descripcion == "Prueba");
                // List<TablaGeneral> lista = unidad.genericDAL.Find(f2).ToList();
                //lista.to
                Genero genero = new Genero
                {
                    id_genero = 2,
                    genero1 = "Prueba2"
                };
                unidad.genericDAL.Update(genero);
                unidad.Complete();
            }
        }
    }
}
