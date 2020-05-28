using System;
using BackEnd.DAL;
using BackEnd.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class Prueba_Rol
    {
        private UnidadDeTrabajo<Role> unidad;

        [TestMethod]
        public void TestMethod1()
        {
            using (unidad = new UnidadDeTrabajo<Role>(new BDContext()))
            {
                // Expression<Func<TablaGeneral, bool>> f2 = (t => t.descripcion == "Prueba");
                // List<TablaGeneral> lista = unidad.genericDAL.Find(f2).ToList();
                //lista.to
                Role rol = new Role
                {
                    RoleId = 1,
                    RoleName = "admin"
                };
                unidad.genericDAL.Add(rol);
                unidad.Complete();
            }
        }

        [TestMethod]
        public void TestMethod2()
        {
            using (unidad = new UnidadDeTrabajo<Role>(new BDContext()))
            {
                // Expression<Func<TablaGeneral, bool>> f2 = (t => t.descripcion == "Prueba");
                // List<TablaGeneral> lista = unidad.genericDAL.Find(f2).ToList();
                //lista.to
                Role rol = new Role
                {
                    RoleId = 1,
                    RoleName = "admin"
                };
                unidad.genericDAL.Remove(rol);
                unidad.Complete();
            }
        }

        [TestMethod]
        public void TestMethod3()
        {
            using (unidad = new UnidadDeTrabajo<Role>(new BDContext()))
            {
                // Expression<Func<TablaGeneral, bool>> f2 = (t => t.descripcion == "Prueba");
                // List<TablaGeneral> lista = unidad.genericDAL.Find(f2).ToList();
                //lista.to
                Role rol = new Role
                {
                    RoleId=1,
                     RoleName="admin"
                      
                };
                unidad.genericDAL.Update(rol);
                unidad.Complete();
            }
        }
    }
}

