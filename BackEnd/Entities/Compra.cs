//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BackEnd.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Compra
    {
        public int id_compra { get; set; }
        public string numeros_asientos { get; set; }
        public int id_cliente { get; set; }
        public string precio_boletos { get; set; }
        public string precio_productos { get; set; }
    }
}