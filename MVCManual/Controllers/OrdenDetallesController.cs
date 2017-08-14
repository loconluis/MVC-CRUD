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
    public class OrdenDetallesController : Controller
    {
        private DataStore db = new DataStore();

        // GET: OrdenDetalles
        [Authorize]
        public ActionResult Index()
        {
            var ordenDetalles = db.OrdenDetalles.Include(o => o.producto);
            return View(ordenDetalles.ToList());
        }
        [Authorize]
        // GET: OrdenDetalles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdenDetalle ordenDetalle = db.OrdenDetalles.Find(id);
            if (ordenDetalle == null)
            {
                return HttpNotFound();
            }
            return View(ordenDetalle);
        }

        // GET: OrdenDetalles/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.codigoproducto = new SelectList(db.Productos, "codigoproducto", "nombre");
            return View();
        }

        // POST: OrdenDetalles/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "nomeroorden,codigoproducto,cantidad,precio")] OrdenDetalle ordenDetalle)
        {
            if (ModelState.IsValid)
            {
                db.OrdenDetalles.Add(ordenDetalle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.codigoproducto = new SelectList(db.Productos, "codigoproducto", "nombre", ordenDetalle.codigoproducto);
            return View(ordenDetalle);
        }

        // GET: OrdenDetalles/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdenDetalle ordenDetalle = db.OrdenDetalles.Find(id);
            if (ordenDetalle == null)
            {
                return HttpNotFound();
            }
            ViewBag.codigoproducto = new SelectList(db.Productos, "codigoproducto", "nombre", ordenDetalle.codigoproducto);
            return View(ordenDetalle);
        }

        // POST: OrdenDetalles/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "nomeroorden,codigoproducto,cantidad,precio")] OrdenDetalle ordenDetalle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ordenDetalle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.codigoproducto = new SelectList(db.Productos, "codigoproducto", "nombre", ordenDetalle.codigoproducto);
            return View(ordenDetalle);
        }

        // GET: OrdenDetalles/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdenDetalle ordenDetalle = db.OrdenDetalles.Find(id);
            if (ordenDetalle == null)
            {
                return HttpNotFound();
            }
            return View(ordenDetalle);
        }

        // POST: OrdenDetalles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrdenDetalle ordenDetalle = db.OrdenDetalles.Find(id);
            db.OrdenDetalles.Remove(ordenDetalle);
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
    }
}
