using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ServiceHogarApp.Models;
using System.IO;

namespace ServiceHogarApp.Controllers
{
    public class ProfesionalController : Controller
    {
        private DB_ServiceHogarEntities db = new DB_ServiceHogarEntities();

        // LISTADO PROFESIONAL
        public ActionResult ListadoProfesional()
        {
            return View(db.TB_Profesionales.ToList());
        }

        // DETALLE PROFESIONAL
        public ActionResult DetalleProfesional(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_Profesionales tB_Profesionales = db.TB_Profesionales.Find(id);
            if (tB_Profesionales == null)
            {
                return HttpNotFound();
            }
            return View(tB_Profesionales);
        }

        // REGISTRAR PROFESIONAL
        public ActionResult RegistroProfesional()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegistroProfesional(HttpPostedFileBase CV, TB_Profesionales p)
        {
            string n = Path.GetFileName(CV.FileName);
            string Folder = Path.Combine(Server.MapPath("~/ArchivosCV"), n);
            CV.SaveAs(Folder);
            int cant = db.SP_REGISTRAR_PROFESIONAL(p.TIPO, p.NOMBRE, p.APELLIDO, p.DNI, p.USUARIO, p.CLAVE, p.SEXO, p.FECHANAC, p.DISTRITO, p.ESPECIALIDAD, p.DESCRIPCIÓN, p.CV = n, p.PROMEDIOCAL);
            if (cant > 0)
            {
                return RedirectToAction("ListadoProfesional");
            }
            else
            {
                return RedirectToAction("ListadoProfesional");
            }
        }

        // EDITAR PROFESIONAL
        public ActionResult EditarProfesional(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_Profesionales tB_Profesionales = db.TB_Profesionales.Find(id);
            if (tB_Profesionales == null)
            {
                return HttpNotFound();
            }
            return View(tB_Profesionales);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarProfesional([Bind(Include = "IDUSUARIO,TIPO,NOMBRE,APELLIDO,DNI,USUARIO,CLAVE,SEXO,FECHANAC,DISTRITO,ESPECIALIDAD,DESCRIPCIÓN,PROMEDIOCAL")] TB_Profesionales tB_Profesionales)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tB_Profesionales).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ListadoProfesional");
            }
            return View(tB_Profesionales);
        }

        // BORRAR PROFESIONAL
        public ActionResult BorrarProfesional(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_Profesionales tB_Profesionales = db.TB_Profesionales.Find(id);
            if (tB_Profesionales == null)
            {
                return HttpNotFound();
            }
            return View(tB_Profesionales);
        }

        [HttpPost, ActionName("BorrarProfesional")]
        [ValidateAntiForgeryToken]
        public ActionResult BorrarProfesional(int id)
        {
            TB_Profesionales tB_Profesionales = db.TB_Profesionales.Find(id);
            db.TB_Profesionales.Remove(tB_Profesionales);
            db.SaveChanges();
            return RedirectToAction("ListadoProfesional");
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
