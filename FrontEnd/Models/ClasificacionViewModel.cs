using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontEnd.Models
{
    public class ClasificacionViewModel
    {
        public int id_clasificacion { get; set; }
        public string tipo_clasificacion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pelicula> Pelicula { get; set; }
    }
}