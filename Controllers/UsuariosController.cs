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
    public class UsuariosController : Controller
    {
        private DB_ServiceHogarEntities db = new DB_ServiceHogarEntities();

        // LISTADO DE USUARIOS
        public ActionResult ListadoUsuarios()
        {
            return View(db.TB_Usuarios.ToList());
        }

        // DETALLE DE USUARIO
        public ActionResult DetalleUsuario(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_Usuarios tB_Usuarios = db.TB_Usuarios.Find(id);
            if (tB_Usuarios == null)
            {
                return HttpNotFound();
            }
            return View(tB_Usuarios);
        }

        // REGISTRO USUARIO
        public ActionResult RegistroUsuario()
        {
            return View();
        }

        // REGISTRO USUARIO [POST]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegistroUsuario([Bind(Include = "IDUSUARIO,TIPO,NOMBRE,APELLIDO,DNI,USUARIO,CLAVE,SEXO,FECHANAC, DISTRITO")] TB_Usuarios tB_Usuarios)
        {
            if (ModelState.IsValid)
            {
                db.TB_Usuarios.Add(tB_Usuarios);
                db.SaveChanges();
                return RedirectToAction("ListadoUsuarios");
            }

            return View(tB_Usuarios);
        }

        // EDITAR USUARIO
        public ActionResult EditarUsuario(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_Usuarios tB_Usuarios = db.TB_Usuarios.Find(id);
            if (tB_Usuarios == null)
            {
                return HttpNotFound();
            }
            return View(tB_Usuarios);
        }

        // EDITAR USUARIO [POST]

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarUsuario([Bind(Include = "IDUSUARIO,TIPO,NOMBRE,APELLIDO,DNI,USUARIO,CLAVE,SEXO,FECHANAC,DISTRITO")] TB_Usuarios tB_Usuarios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tB_Usuarios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ListadoUsuarios");
            }
            return View(tB_Usuarios);
        }

        // BORRAR USUARIO
        public ActionResult BorrarUsuario(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_Usuarios tB_Usuarios = db.TB_Usuarios.Find(id);
            if (tB_Usuarios == null)
            {
                return HttpNotFound();
            }
            return View(tB_Usuarios);
        }

        // BORRAR USUARIO [POST]

        [HttpPost, ActionName("BorrarUsuario")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TB_Usuarios tB_Usuarios = db.TB_Usuarios.Find(id);
            db.TB_Usuarios.Remove(tB_Usuarios);
            db.SaveChanges();
            return RedirectToAction("ListadoUsuarios");
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
