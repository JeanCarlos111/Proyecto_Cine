﻿using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FrontEnd.Models
{
    public class UserViewModel
    {
        public int UserViewModelId { get; set; }

        [Required(ErrorMessage = "Debe digitar un Nombre de Usuario.")]
        [Display(Name = "Usuario")]
        public string UserName { get; set; }

        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Debe digitar una Contraseña.")]
        [Display(Name = "Contraseña")]
        public string Contrasena { get; set; }

        [Required(ErrorMessage = "Debe digitar un Correo")]
       
        [Display(Name = "Correo")]
        public string mail { get; set; }

        [Display(Name = "Teléfono")]
        public string phone { get; set; }

        [Display(Name = "Apellidos")]
        public string apellidos { get; set; }

        [Required(ErrorMessage = "Debe digitar una trajeta de credito")]

        [Display(Name = "Tarjeta")]
        public string tarjeta { get; set; }

        public Nullable<int> id_rol { get; set; }

        public string LoginErrorMessage { get; set; }

        public virtual ICollection<Roles> Roles { get; set; }

    }
}