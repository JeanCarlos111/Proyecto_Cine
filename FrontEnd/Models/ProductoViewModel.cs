using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FrontEnd.Models
{
    public class ProductoViewModel
    {
        
        public string id_comida { get; set; }
        public string nombre { get; set; }
        public string precio { get; set; }
        public string cantidad { get; set; }
        public string imagen_comida { get; set; }

     
      
    }
}