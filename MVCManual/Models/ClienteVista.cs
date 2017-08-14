using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCManual.Models
{
    public class ClienteVista:Clientes
    {
        [Display(Name = "Fecha de Orden")]
        [DataType(DataType.Date)]
        public DateTime fecha { set; get; }
    }
}