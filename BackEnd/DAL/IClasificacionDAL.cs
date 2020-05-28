using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
   public interface IClasificacionDAL
    {
        void AddClasficacion(Clasificacion clasificacion);
        void UpdateClasificacion(Clasificacion clasificacion);
        void DeleteClasificacion(int id);
        List<Clasificacion> GetClasificacion();
        Clasificacion GetClasificacionById(int id);
    }
}
