using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FrontEnd.Models
{
    public class ComidasViewModel
    {
        [Required(ErrorMessage = "Debe digitar un ID de comida")]
        [Display(Name = "Identificador de la comida")]
        public int id_comida { get; set; }
        [Display(Name = "Nombre")]
        public string nombre { get; set; }
        [Display(Name = "Precio")]
        public string precio { get; set; }
        [Display(Name = "Cantidad")]
        public string cantidad { get; set; }
        [Display(Name ="Imagen")]
        public string imagen_comida { get; set; }

     
      
    }
}