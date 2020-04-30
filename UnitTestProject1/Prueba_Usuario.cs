using System;
using BackEnd.DAL;
using BackEnd.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class Prueba_Usuario
    {
        private UnidadDeTrabajo<User> unidad;

        [TestMethod]
        public void TestMethod1()
        {
            using (unidad = new UnidadDeTrabajo<User>(new BDContext()))
            {
                // Expression<Func<TablaGeneral, bool>> f2 = (t => t.descripcion == "Prueba");
                // List<TablaGeneral> lista = unidad.genericDAL.Find(f2).ToList();
                //lista.to
                User usuario = new User
                {
                    apellidos = "",
                    card = "",
                    mail = "",
                    nombre = "",
                    Password = "",
                    phone = "",
                    UserId = 1,
                    UserName = ""
                };
                unidad.genericDAL.Add(usuario);
                unidad.Complete();
            }
        }

        [TestMethod]
        public void TestMethod2()
        {
            using (unidad = new UnidadDeTrabajo<User>(new BDContext()))
            {
                // Expression<Func<TablaGeneral, bool>> f2 = (t => t.descripcion == "Prueba");
                // List<TablaGeneral> lista = unidad.genericDAL.Find(f2).ToList();
                //lista.to
                User usuario = new User
                {
                    apellidos = "",
                    card = "",
                    mail = "",
                    nombre = "",
                    Password = "",
                    phone = "",
                    UserId = 1,
                    UserName = ""
                };
                unidad.genericDAL.Remove(usuario);
                unidad.Complete();
            }
        }

        [TestMethod]
        public void TestMethod3()
        {
            using (unidad = new UnidadDeTrabajo<User>(new BDContext()))
            {
                // Expression<Func<TablaGeneral, bool>> f2 = (t => t.descripcion == "Prueba");
                // List<TablaGeneral> lista = unidad.genericDAL.Find(f2).ToList();
                //lista.to
                User usuario = new User
                {
                    apellidos="",
                     card="", 
                      mail="",
                       nombre="",
                        Password="",
                         phone="",
                          UserId=1,
                           UserName=""
                         
                };

                unidad.genericDAL.Update(usuario);
                unidad.Complete();
            }
        }
    }
}

