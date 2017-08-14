using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCManual.Models
{
    public class ProductoVista:Productos
    {
        [Display(Name ="Cantidad a Pedir")]
        public int cantidad { set; get; }
    }
}