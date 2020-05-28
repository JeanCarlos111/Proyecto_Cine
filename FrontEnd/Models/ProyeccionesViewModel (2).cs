using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontEnd.Models
{
    public class ProyeccionesViewModel
    {
        public int id_proyeccion { get; set; }
        public Nullable<int> id_sala { get; set; }
        public Nullable<int> id_pelicula { get; set; }
        public string hora { get; set; }

        public virtual Pelicula Pelicula { get; set; }
        public virtual Sala Sala { get; set; }

        public virtual Clasificacion Clasificacion { get; set; }

        public virtual Formato Formato { get; set; }

        public virtual List<Asiento> Asiento { get; set; }

    }
}