using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
   public interface IProyeccionDAL
    {
        void AddProyeccion(Proyeccion proyeccion);
        void UpdateProyeccion(Proyeccion proyeccion);
        void DeleteProyeccion(int id);
        List <Proyeccion> GetProyecciones ();
        Proyeccion GetProyeccionesById(int id);
    }
}
