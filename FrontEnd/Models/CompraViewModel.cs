using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FrontEnd.Models
{
    public class CompraViewModel
    {
 
        public string sala { get; set; }

        public List<string>numero_asiento {get;set;}

        public string cantidad_asientos { get; set; }

        public string precio_entradas { get; set; }

    }
}