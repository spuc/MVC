using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace claseMVCts.Controllers
{
    public class deportesController : Controller
    {
        //
        // GET: /deportes/
        //[ActionName("Patito")]
        //string categoria = "futbol"
        [HttpGet]
        public ActionResult Index()
        {
            //ViewBag.deporte = categoria;
            
            //return RedirectToAction("Index", "Home");
            //return RedirectToRoute("Default", new
            //{
            //    Controller = "Home",
            //    action = "About"
            //});
            //var message = Server.HtmlEncode(categoria);
            //return Json(new { Message = message, 
            //    Name = "deporte" }, 
            //    JsonRequestBehavior.AllowGet);
            
            return View("Index");

        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string valor)
        {
            ViewBag.deporte = valor;
            return View();
            
        }

        public ActionResult natacion()
        {
            return View();
        }

        public ActionResult futbol()
        {
            return View();
        }

        public ActionResult especifico()
        {
            return View();
        }

    }
}
