using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontEnd.Models
{
    public class SalaViewModel
    {
        public int id_sala { get; set; }
        public string sala1 { get; set; }
        public Nullable<int> cantidad_asientos { get; set; }
        public int id_asiento { get; set; }
        public Nullable<int> numero_sala { get; set; }

        public virtual Asiento Asiento { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Proyeccion> Proyeccion { get; set; }
    }
}