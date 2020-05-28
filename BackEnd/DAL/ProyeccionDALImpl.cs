using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public class ProyeccionDALImpl : IProyeccionDAL
    {
        private BDContext context;

        public void AddProyeccion(Proyeccion proyeccion)
        {
            using (context = new BDContext())
            {
                context.Proyeccion.Add(proyeccion);
                context.SaveChanges();
            }
        }

        public void UpdateProyeccion(Proyeccion proyeccion)
        {
            using (context = new BDContext())
            {
                context.Entry(proyeccion).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteProyeccion(int id)
        {
            using (context = new BDContext())
            {
                Proyeccion proyeccion;
                proyeccion = (from p in context.Proyeccion
                        where p.id_proyeccion == id
                        select p).FirstOrDefault();
                context.Proyeccion.Remove(proyeccion);
                context.SaveChanges();
            }
        }


        public List<Proyeccion> GetProyecciones()
        {
            List<Proyeccion> result;
            using (context = new BDContext())
            {
                result = (from p in context.Proyeccion
                          select p).ToList();
            }
            return result;
        }

        public Proyeccion GetProyeccionesById(int id)
        {
            Proyeccion result;
            using (context = new BDContext())
            {
                result = (from p in context.Proyeccion
                          where p.id_proyeccion == id
                          select p).FirstOrDefault();
            }
            return result;
        }
    }
}
