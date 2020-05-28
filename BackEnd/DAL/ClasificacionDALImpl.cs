using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public class ClasificacionDALImpl : IClasificacionDAL
    {
        private BDContext context;
        public void AddClasficacion(Clasificacion clasificacion)
        {

            using (context = new BDContext())
            {
                context.Clasificacion.Add(clasificacion);
                context.SaveChanges();
            }
        }

        public void UpdateClasificacion(Clasificacion clasificacion)
        {
            using (context = new BDContext())
            {
                context.Entry(clasificacion).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteClasificacion(int id)
        {
            using (context = new BDContext())
            {
                Clasificacion clasificacion;
                clasificacion = (from c in context.Clasificacion
                            where c.id_clasificacion == id
                            select c).FirstOrDefault();
                context.Clasificacion.Remove(clasificacion);
                context.SaveChanges();
            }
        }

        public List<Clasificacion> GetClasificacion()
        {
            List<Clasificacion> result;
            using (context = new BDContext())
            {
                result = (from c in context.Clasificacion
                          select c).ToList();
            }
            return result;
        }

        public Clasificacion GetClasificacionById(int id)
        {
            Clasificacion result;
            using (context = new BDContext())
            {
                result = (from c in context.Clasificacion
                          where c.id_clasificacion == id
                          select c).FirstOrDefault();
            }
            return result;
        }
    }
}
