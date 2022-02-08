using ServiceHogarApp.Models;
using System.Linq;
using System.Web.Mvc;


namespace ServiceHogarApp.Controllers
{
    public class LoginController : Controller
    {
        // PRIMERA PANTALLA

        public ActionResult Bienvenido()
        {
            return View();
        }

        // SEGUNDA PANTALLA

        public ActionResult TipoDeUsuario()
        {
            return View();
        }

        // LOGIN

        public ActionResult Login(TB_Usuarios objUser)
        {
           if (ModelState.IsValid)
            {
                using (DB_ServiceHogarEntities db = new DB_ServiceHogarEntities())
                {
                    var obj = db.TB_Usuarios.Where(a => a.USUARIO.Equals(objUser.USUARIO) && a.CLAVE.Equals(objUser.CLAVE) && a.TIPO.Equals("Usuario")).FirstOrDefault();
                    var obj2 = db.TB_Profesionales.Where(a => a.USUARIO.Equals(objUser.USUARIO) && a.CLAVE.Equals(objUser.CLAVE) && a.TIPO.Equals("Profesional")).FirstOrDefault();

                    if (obj != null)
                    {
                        Session["USUARIO"] = obj;
                        Session["IDUSUARIO"] = obj.IDUSUARIO.ToString();
                        Session["NOMBRE"] = obj.NOMBRE.ToString();
                        //return RedirectToAction("Index");  
                        return RedirectToAction("ListadoServicios", "Servicios");
                    }
                    if (obj2 != null)
                    {
                        //Session["IDUSUARIO"] = obj.IDUSUARIO.ToString();
                        //Session["NOMBRE"] = obj.NOMBRE.ToString();
                        //return RedirectToAction("Index");  
                        return RedirectToAction("Index", "Profesionales");
                    }
                }

            }
            return View(objUser);
        }
    }
}