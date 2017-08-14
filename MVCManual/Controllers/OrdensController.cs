using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCManual.Context;
using MVCManual.Models;

namespace MVCManual.Controllers
{
    public class OrdensController : Controller
    {
        private DataStore db = new DataStore();

        [Authorize]
        // GET: Ordens
        public ActionResult Index()
        {
            var ordens = db.Ordens.Include(o => o.cliente);
            return View(ordens.ToList());
        }

        [Authorize]
        // GET: Ordens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orden orden = db.Ordens.Find(id);
            if (orden == null)
            {
                return HttpNotFound();
            }
            return View(orden);
        }

        [Authorize]
        // GET: Ordens/Create
        public ActionResult Create()
        {
            ViewBag.codigocliente = new SelectList(db.Clientes, "codigocliente", "nombre");
            return View();
        }

        // POST: Ordens/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "numOrden,fecha,codigocliente")] Orden orden)
        {
            if (ModelState.IsValid)
            {
                db.Ordens.Add(orden);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.codigocliente = new SelectList(db.Clientes, "codigocliente", "nombre", orden.codigocliente);
            return View(orden);
        }

        [Authorize]
        // GET: Ordens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orden orden = db.Ordens.Find(id);
            if (orden == null)
            {
                return HttpNotFound();
            }
            ViewBag.codigocliente = new SelectList(db.Clientes, "codigocliente", "nombre", orden.codigocliente);
            return View(orden);
        }

        // POST: Ordens/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "numOrden,fecha,codigocliente")] Orden orden)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orden).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.codigocliente = new SelectList(db.Clientes, "codigocliente", "nombre", orden.codigocliente);
            return View(orden);
        }

        [Authorize]
        // GET: Ordens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orden orden = db.Ordens.Find(id);
            if (orden == null)
            {
                return HttpNotFound();
            }
            return View(orden);
        }

        // POST: Ordens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Orden orden = db.Ordens.Find(id);
            db.Ordens.Remove(orden);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Detalle(int id)
        {
            return PartialView(db.OrdenDetalles.Where(x=> x.nomeroorden==id).ToList());
        }
    }
}
