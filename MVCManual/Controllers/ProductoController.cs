using MVCManual.Context;
using MVCManual.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVCManual.Controllers
{
    public class ProductoController : Controller
    {
        private DataStore db = new DataStore();

        [Authorize]
        // GET: Producto
        public ActionResult Index()
        {
            return View(db.Productos.ToList());
        }

        [Authorize]
        // GET: Producto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                Productos x = db.Productos.Find(id);
                if (x == null)
                {
                    //haga algo
                    return HttpNotFound();
                }
                else
                {
                    return View(x);
                }
            }
            
        }

        [Authorize]
        // GET: Producto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Producto/Create
        [HttpPost]
        public ActionResult Create(Productos x)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    db.Productos.Add(x);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [Authorize]
        // GET: Producto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                Productos x = db.Productos.Find(id);
                if (x == null)
                {
                    //haga algo
                    return HttpNotFound();
                }
                else
                {
                    return View(x);
                }
            }
        }

        // POST: Producto/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Productos producto)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    db.Entry(producto).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [Authorize]
        // GET: Producto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                Productos x = db.Productos.Find(id);
                if (x == null)
                {
                    //haga algo
                    return HttpNotFound();
                }
                else
                {
                    return View(x);
                }
            }
        }

        // POST: Producto/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Productos producto)
        {
            try
            {
                // TODO: Add delete logic here
                    producto = db.Productos.Find(id);
                    if (producto == null)
                    {
                        //haga algo
                        return HttpNotFound();
                    }
                    else
                    {
                        db.Productos.Remove(producto);
                        db.SaveChanges();
                    }
                
                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
