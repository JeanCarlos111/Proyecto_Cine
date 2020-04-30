using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FrontEnd.Models
{
    public class ReservaViewModel

    {
        public int id_reserva { get; set; }
        public Nullable<int> id_asiento { get; set; }
        public Nullable<int> id_cliente { get; set; }
        public string estado_reserva { get; set; }

        public virtual Asiento Asiento { get; set; }

    }
}
