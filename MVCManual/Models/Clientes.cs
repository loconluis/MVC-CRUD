using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCManual.Models
{
    public class Clientes
    {
        [Key]
        [Display(Name ="Codigo Cliente")]
        public int codigocliente { set; get; }
        [Display(Name = "Nombre Cliente")]
        public string nombre { set; get; }
        [Display(Name = "Direccion")]
        public string direccion { set; get; }
        [Display(Name = "Email")]
        public string correo { set; get; }
        [Display(Name = "Telefono")]
        public string telefono { set; get; }
        public ICollection<Orden> orden { set; get; }
    }
}