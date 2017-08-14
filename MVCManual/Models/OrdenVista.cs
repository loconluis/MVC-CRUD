using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCManual.Models
{
    public class OrdenVista
    {
        public ClienteVista cliente { set; get; }
        public ProductoVista Titulos { set; get; }
        public List<ProductoVista> Lproducto { set; get; }

    }
}