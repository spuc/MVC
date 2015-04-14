using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using claseMVCts.Models;

namespace claseMVCts.Controllers
{
    public class servicioslibroController : ApiController
    {
        private LibroDBContext db = new LibroDBContext();

        // GET api/servicioslibro
        public IEnumerable<libro> Getlibroes()
        {
            return db.libros.AsEnumerable();
        }

        // GET api/servicioslibro/5
        public libro Getlibro(int id)
        {
            libro libro = db.libros.Find(id);
            if (libro == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return libro;
        }

        // PUT api/servicioslibro/5
        public HttpResponseMessage Putlibro(int id, libro libro)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != libro.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(libro).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/servicioslibro
        public HttpResponseMessage Postlibro(libro libro)
        {
            if (ModelState.IsValid)
            {
                db.libros.Add(libro);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, libro);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = libro.Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/servicioslibro/5
        public HttpResponseMessage Deletelibro(int id)
        {
            libro libro = db.libros.Find(id);
            if (libro == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.libros.Remove(libro);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, libro);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}