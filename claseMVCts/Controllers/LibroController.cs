using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using claseMVCts.Models;
using PagedList;

namespace claseMVCts.Controllers
{
    public class LibroController : Controller
    {
        private LibroDBContext db = new LibroDBContext();


        public ActionResult libros(int page = 1)
        {

            return View(db.libros.ToList().ToPagedList(page, 10));
        }

        //
        // GET: /Default1/

        public ActionResult Index(int page = 1, string SelectedText = "")
        {
            var categorias = GetGeneros();
            var genero = SelectedText;
            ViewBag.SelectedItem = genero;
            ViewBag.generos = new SelectList(categorias,genero);
            //-------------------
            if (genero != string.Empty)
            {
                var query = BuscarGenerosPaginacion(genero, page);
                if (Request.IsAjaxRequest())
                {
                    return PartialView("_Resultados", query);
                }

                return View(query);
            }

            if (Request.IsAjaxRequest())
            {
                return PartialView("_Resultados", db.libros.ToList().ToPagedList(page, 10));
            }
            return View(db.libros.ToList().ToPagedList(page, 10));

        }

        [HttpPost]
        public ActionResult Index(string genero, int page = 1)
        {
            System.Environment.Exit(1);
            ViewBag.SelectedItem = genero;

            var categorias = GetGeneros();
            ViewBag.SelectedItem = genero;
            ViewBag.generos = new SelectList(categorias,  genero);
            //-------------------
            if (genero != string.Empty)
            {
                //var query = BuscarGeneros(generos);
                var query = BuscarGenerosPaginacion(genero, page);

                //if (IsAjaxRequest())
                if (Request.IsAjaxRequest())
                {
                    return PartialView("_Resultados", query);
                }

                return View(query);
            }

            if (Request.IsAjaxRequest())
            {
                return PartialView("_Resultados", db.libros.ToList().ToPagedList(page, 10));
            }
            return View(db.libros.ToList().ToPagedList(page, 10));

        }

        private List<string> GetGeneros()
        {
            var nodos = new List<string>();

            var query = from d in db.libros
                        orderby d.Genero
                        where d.Genero != string.Empty
                        select d.Genero;
            nodos.AddRange(query.Distinct());
            return nodos;
        }

        //private List<string> getGeneros()
        //{             

        //    var nodos = new List<string>();

        //    if (System.Web.HttpContext.Current.Cache["categorias"] == null)
        //    {

        //        var query = from d in db.libros
        //                    orderby d.Genero
        //                    where d.Genero != string.Empty
        //                    select d.Genero;
        //        nodos.AddRange(query.Distinct());

        //        System.Web.HttpContext.Current.Cache["categorias"] = nodos;
        //    }

        //    ViewBag.generos = (System.Web.HttpContext.Current.Cache["categorias"]).ToString();


        //    return nodos;
        //}



        public bool IsAjaxRequest()
        {
            return HttpContext.Request.Headers["X-Requested-With"] != null
                && HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest";
        }

        
       

        private IQueryable<libro> BuscarGeneros(string generos)
        {
            var query = from d in db.libros
                        orderby d.Genero
                        where d.Genero == generos
                        select d;

            return query;
        }


        public IPagedList<libro> BuscarGenerosPaginacion(string generos, 
            int page = 1)
        {
            var query = (from d in db.libros
                        orderby d.Genero
                        where d.Genero == generos
                         select d); 

            var resultados  = query.ToList().ToPagedList(page, 10);
            return resultados;
        }

        //
        // GET: /Default1/Details/5

        public ActionResult Details(int id = 0)
        {
            libro libro = db.libros.Find(id);
            if (libro == null)
            {
                return HttpNotFound();
            }
            return View(libro);
        }

        //
        // GET: /Default1/Create

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult toastr()
        {
            return View();
        }

        public ActionResult llamadaServicioLibro()
        {
            return View();
        }

        //
        // POST: /Default1/Create

        [HttpPost]
        public ActionResult Create(libro libro)
        {
            if (ModelState.IsValid)
            {
                db.libros.Add(libro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(libro);
        }

        //
        // GET: /Default1/Edit/5

        public ActionResult Edit(int id = 0)
        {
            libro libro = db.libros.Find(id);
            if (libro == null)
            {
                //return HttpNotFound();
                ViewBag.Message = "El libro " + id + "  no fue encontrado";
            }

            return View(libro);
        }

        //
        // POST: /Default1/Edit/5

        [HttpPost]
        public ActionResult Edit(libro libro , HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file.ContentLength > 0) {
                    
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(
                        Server.MapPath("~/Content/imagenes"), 
                        fileName);
                    file.SaveAs(path);
                    
                    path = Url.Content(Path.Combine("~/content/imagenes", 
                        fileName));
                    // save to db
                    libro.ruta = path;
                }

                db.Entry(libro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(libro);
        }

        //
        // GET: /Default1/Delete/5

        public ActionResult Delete(int id = 0)
        {
            libro libro = db.libros.Find(id);
            if (libro == null)
            {
                return HttpNotFound();
            }
            return View(libro);
        }

        //
        // POST: /Default1/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            libro libro = db.libros.Find(id);
            db.libros.Remove(libro);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //[HttpPost]
        //public ActionResult FileUpload(HttpPostedFileBase file)
        public bool uploadFile(HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file == null)
                {
                    ModelState.AddModelError("File", "Please Upload Your file");
                }
                else if (file.ContentLength > 0)
                {
                    int MaxContentLength = 1024 * 1024 * 3; //3 MB
                    string[] AllowedFileExtensions = new string[] { ".jpg", ".gif", ".png", ".pdf" };

                    if (!AllowedFileExtensions.Contains(file.FileName.Substring(file.FileName.LastIndexOf('.'))))
                    {
                        ModelState.AddModelError("File", "Please file of type: " + string.Join(", ", AllowedFileExtensions));
                    }

                    else if (file.ContentLength > MaxContentLength)
                    {
                        ModelState.AddModelError("File", "Your file is too large, maximum allowed size is: " + MaxContentLength + " MB");
                    }
                    else
                    {
                        //TO:DO
                        var fileName = Path.GetFileName(file.FileName);
                        var path = Path.Combine(Server.MapPath("~/Content/Upload"), fileName);
                        file.SaveAs(path);
                        ModelState.Clear();
                        ViewBag.Message = "File uploaded successfully";
                    }
                }
            }
            //return View();
            return true;
        }


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}