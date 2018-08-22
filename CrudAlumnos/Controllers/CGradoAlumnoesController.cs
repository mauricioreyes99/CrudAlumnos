using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CrudAlumnos.AlumnosContext;
using CrudAlumnos.Models;

namespace CrudAlumnos.Controllers
{
    public class CGradoAlumnoesController : Controller
    {
        private AlumnosC db = new AlumnosC();

        // GET: CGradoAlumnoes
        public ActionResult Index()
        {
            return View(db.CGradoAlumnoes.ToList());
        }

        // GET: CGradoAlumnoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CGradoAlumno cGradoAlumno = db.CGradoAlumnoes.Find(id);
            if (cGradoAlumno == null)
            {
                return HttpNotFound();
            }
            return View(cGradoAlumno);
        }

        // GET: CGradoAlumnoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CGradoAlumnoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDGrado,GradoAlumno")] CGradoAlumno cGradoAlumno)
        {
            if (ModelState.IsValid)
            {
                db.CGradoAlumnoes.Add(cGradoAlumno);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cGradoAlumno);
        }

        // GET: CGradoAlumnoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CGradoAlumno cGradoAlumno = db.CGradoAlumnoes.Find(id);
            if (cGradoAlumno == null)
            {
                return HttpNotFound();
            }
            return View(cGradoAlumno);
        }

        // POST: CGradoAlumnoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDGrado,GradoAlumno")] CGradoAlumno cGradoAlumno)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cGradoAlumno).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cGradoAlumno);
        }

        // GET: CGradoAlumnoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CGradoAlumno cGradoAlumno = db.CGradoAlumnoes.Find(id);
            if (cGradoAlumno == null)
            {
                return HttpNotFound();
            }
            return View(cGradoAlumno);
        }

        // POST: CGradoAlumnoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CGradoAlumno cGradoAlumno = db.CGradoAlumnoes.Find(id);
            db.CGradoAlumnoes.Remove(cGradoAlumno);
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
