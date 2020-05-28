using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BackEnd.Entities;

namespace FrontEnd.Models
{
    public class GeneroViewModel
    {
        public int id_genero { get; set; }
        public string genero1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pelicula> Pelicula { get; set; }
    }
}