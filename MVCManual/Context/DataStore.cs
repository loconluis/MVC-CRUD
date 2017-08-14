using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCManual.Models;
using System.Data.Entity;

namespace MVCManual.Context
{
    public class DataStore:DbContext
    {
        public DbSet<Productos> Productos { set; get; }
        public DbSet<Clientes> Clientes { set; get; }

        public System.Data.Entity.DbSet<MVCManual.Models.Orden> Ordens { get; set; }

        public System.Data.Entity.DbSet<MVCManual.Models.OrdenDetalle> OrdenDetalles { get; set; }
    }
}