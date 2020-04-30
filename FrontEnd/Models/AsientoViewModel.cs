using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontEnd.Models
{
    public class AsientoViewModel
    {
        public int id_asiento { get; set; }
        public Nullable<int> id_sala { get; set; }
        public Nullable<int> estado { get; set; }
        public string numero_asiento { get; set; }
    }
}