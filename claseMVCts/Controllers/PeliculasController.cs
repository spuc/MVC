using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using claseMVCts.Models;
using System.Data.SqlClient;

namespace claseMVCts.Controllers
{
    public class PeliculasController : Controller
    {
        private PeliculasContext db = new PeliculasContext();

        //
        // GET: /Peliculas/

        public ActionResult Index()
        {
            return View(db.Peliculas.ToList());
        }

        //
        // GET: /Peliculas/Details/5

        public ActionResult Details(int id = 0)
        {
            /*Pelicula pelicula = db.Peliculas.Find(id);
            if (pelicula == null)
            {
                return HttpNotFound();
            }*/

            var idParam2 = new SqlParameter
            {
                ParameterName = "Id",
                Value = id
            };
            //var pelicula = db.Peliculas.SqlQuery(
            // "exec GetPeliculasById @Id ", idParam2).ToList<Pelicula>();
            //return View(pelicula);

            Pelicula pel = db.Database.SqlQuery<Pelicula>
                ("exec GetPeliculasById @Id ", idParam2)
                .FirstOrDefault<Pelicula>();

            return View(pel);
        }

        //
        // GET: /Peliculas/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Peliculas/Create

        [HttpPost]
        public ActionResult Create(Pelicula pelicula)
        {
            if (ModelState.IsValid)
            {
                db.Peliculas.Add(pelicula);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pelicula);
        }

        //
        // GET: /Peliculas/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Pelicula pelicula = db.Peliculas.Find(id);
            if (pelicula == null)
            {
                return HttpNotFound();
            }
            return View(pelicula);
        }

        //
        // POST: /Peliculas/Edit/5

        [HttpPost]
        public ActionResult Edit(Pelicula pelicula)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pelicula).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pelicula);
        }

        //
        // GET: /Peliculas/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Pelicula pelicula = db.Peliculas.Find(id);
            if (pelicula == null)
            {
                return HttpNotFound();
            }
            return View(pelicula);
        }

        //
        // POST: /Peliculas/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Pelicula pelicula = db.Peliculas.Find(id);
            db.Peliculas.Remove(pelicula);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}