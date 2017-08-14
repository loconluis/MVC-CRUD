using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCManual.Models
{
    public class OrdenDetalle
    {
        [Key]
        [Display(Name = "Numero Detalle:")]
        public Int32 codigodetalle { set; get; }
        [Display(Name ="Numero de Orden:")]
        public int nomeroorden { set; get; }
        [Display(Name = "Codigo Producto")]
        public int codigoproducto { set; get; }
        [Display(Name = "Cantidad")]
        public int cantidad { set; get; }
        [Display(Name = "Precio")]
        [DisplayFormat(DataFormatString ="{0:C2}", ApplyFormatInEditMode =false)]
        public decimal precio { set; get; }

        public virtual Orden orden { set; get; }
        public virtual Productos producto { set; get; }
    }
}