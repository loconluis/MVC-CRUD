using MVCManual.Context;
using MVCManual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCManual.Controllers
{
    public class VentasController : Controller
    {
        private DataStore db = new DataStore();


        // GET: Ventas
        [Authorize]
        public ActionResult Index(Orden ordi)
        {
            //Session["header"] = Convert.ToDateTime(Request["cliente.fecha"]);

            OrdenVista ov = new OrdenVista();
            ov.cliente = new ClienteVista();
            ov.Lproducto = new List<ProductoVista>();
            Session["OrderView"] = ov;
            ordi = Session["dataheader"] as Orden;
            if (ordi != null)
            {
                var list = ordi.codigocliente.ToString().ToList();
                ViewBag.codigocliente = new SelectList(list, "codigocliente", "nombre");
            }
            else
            {
                var list = db.Clientes.ToList();
                ViewBag.codigocliente = new SelectList(list, "codigocliente", "nombre");
            }
            return View(ov);
        }
        [HttpPost]
        public ActionResult Index(OrdenVista orderview)
        {
            orderview = Session["OrderView"] as OrdenVista;
            int idcliente = Convert.ToInt32(Request["codigocliente"]);
            DateTime fechaorden = Convert.ToDateTime(Request["cliente.fecha"]);


            Orden or = new Orden
            {
                codigocliente= idcliente,
                fecha= fechaorden
            };

            Session["dataheader"] = or;
            db.Ordens.Add(or);
            db.SaveChanges();

            int ultimoidorden = db.Ordens.ToList().Select(o=>o.numeroorden).Max();
            foreach(ProductoVista item in orderview.Lproducto)
            {
                var detalle = new OrdenDetalle()
                {
                    nomeroorden = ultimoidorden,
                    codigoproducto = item.codigoproducto,
                    cantidad = item.cantidad,
                    precio = item.precio,
                };
                db.OrdenDetalles.Add(detalle);
            }
            db.SaveChanges();

            var list = db.Clientes.ToList();
            ViewBag.codigocliente = new SelectList(list, "codigocliente", "nombre");
            return View(orderview);
        }

        [HttpGet]
        [Authorize]
        public ActionResult AgregarProducto()
        {
            //Orden o = (Orden)Session["dataheader"];
            var list = db.Productos.ToList();
            //var list2 = o.codigocliente.ToString().ToList();
            
            ViewBag.codigoproducto = new SelectList(list, "codigoproducto", "nombre");
            return View();
        }

        [HttpPost]
        public ActionResult AgregarProducto( ProductoVista pv)
        {
            var orderview = Session["OrderView"] as OrdenVista;
            var productoid = int.Parse(Request["codigoproducto"]);
            var productoe = db.Productos.Find(productoid);
            pv = new ProductoVista()
            {
                codigoproducto = productoe.codigoproducto,
                nombre = productoe.nombre,
                precio = productoe.precio,
                cantidad = int.Parse(Request["cantidad"])
            };
            orderview.Lproducto.Add(pv);
            var list = db.Clientes.ToList();
            ViewBag.codigocliente = new SelectList(list, "codigocliente", "nombre");
            var listp = db.Productos.ToList();
            ViewBag.codigoproducto = new SelectList(listp, "codigoproducto", "nombre");
            return View("Index", orderview);
        }
    }
}