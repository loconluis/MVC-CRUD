using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCManual.Models
{
    public class Productos
    {
        [Key]
        public int codigoproducto { set; get; }
        [Display(Name = "Nombre Producto: ")]
        [StringLength(50, ErrorMessage ="El campo {0} debe estar entre {1} y {2} caracteres", MinimumLength =3)]
        [Required(ErrorMessage ="El campo {0} es requerido")]
        public string nombre { set; get; }
        [Display(Name = "Descripción Producto: ")]
        public string descripcion { set; get; }
        [Display(Name = "Precio: ")]
        public decimal precio { set; get; }
        [Display(Name = "Fecha ultima compra: ")]
        [DataType(DataType.Date)]
        public DateTime ultimacompra { set; get; }
        [Display(Name = "Existencia: ")]
        public int unidadesinventario { set; get; }
        
        public ICollection<OrdenDetalle> OrdenDetalle { set; get; }
    }
}