using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontEnd.Models
{
    public class PeliculaViewModel
    {

        public int id_pelicula { get; set; }
        public int id_clasifacion { get; set; }
        public string nombre_pelicula { get; set; }
        public string duracion_pelicula { get; set; }
        public int id_genero { get; set; }
        public string imagen_pelicula { get; set; }
        public int id_formato { get; set; }

        public virtual Clasificacion Clasificacion { get; set; }
        public virtual Formato Formato { get; set; }
        public virtual Genero Genero { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Proyeccion> Proyeccion { get; set; }
    }
}