using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ServiceHogarApp.Models;

namespace ServiceHogarApp.Controllers
{
    public class ServiciosController : Controller
    {
        private DB_ServiceHogarEntities db = new DB_ServiceHogarEntities();

        // GET: Servicios
        public ActionResult ListadoServicios()
        {
            return View(db.TB_Servicios.ToList());
        }

        // GET: Servicios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_Servicios tB_Servicios = db.TB_Servicios.Find(id);
            if (tB_Servicios == null)
            {
                return HttpNotFound();
            }
            return View(tB_Servicios);
        }

        // GET: Servicios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Servicios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDSERVICIO,NOMBRESERV")] TB_Servicios tB_Servicios)
        {
            if (ModelState.IsValid)
            {
                db.TB_Servicios.Add(tB_Servicios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tB_Servicios);
        }

        // GET: Servicios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_Servicios tB_Servicios = db.TB_Servicios.Find(id);
            if (tB_Servicios == null)
            {
                return HttpNotFound();
            }
            return View(tB_Servicios);
        }

        // POST: Servicios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDSERVICIO,NOMBRESERV")] TB_Servicios tB_Servicios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tB_Servicios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tB_Servicios);
        }

        // GET: Servicios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_Servicios tB_Servicios = db.TB_Servicios.Find(id);
            if (tB_Servicios == null)
            {
                return HttpNotFound();
            }
            return View(tB_Servicios);
        }

        // POST: Servicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TB_Servicios tB_Servicios = db.TB_Servicios.Find(id);
            db.TB_Servicios.Remove(tB_Servicios);
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
