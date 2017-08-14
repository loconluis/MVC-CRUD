using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCManual.Models
{
    public class Orden
    {
        [Key]
        [Display(Name = "Numero de Orden")]
        public int numeroorden { set; get; }
        [Display(Name = "Fecha de Orden")]
        public DateTime fecha { set; get; }
        [Display(Name ="Codigo del Cliente")]
        public int codigocliente { set; get; }
        public virtual Clientes cliente { set; get; }
        public ICollection<OrdenDetalle> detalle { set; get; }
    }
}