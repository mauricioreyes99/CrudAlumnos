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
    public class AlumnosController : Controller
    {
        private AlumnosC db = new AlumnosC();

        // GET: Alumnos
        public ActionResult Index()
        {
            var alumnos = db.Alumnos.Include(a => a.CGradoAlumno);
            return View(alumnos.ToList());
        }

        // GET: Alumnos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alumnos alumnos = db.Alumnos.Find(id);
            if (alumnos == null)
            {
                return HttpNotFound();
            }
            return View(alumnos);
        }

        // GET: Alumnos/Create
        public ActionResult Create()
        {
            ViewBag.IDGrado = new SelectList(db.CGradoAlumnoes, "IDGrado", "GradoAlumno");
            return View();
        }

        // POST: Alumnos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_alumno,NombreAlumno,ApelidoAlumno,DireccionAlumno,TelefonoAlumno,EmailAlumno,FechaIngreso,HoraIngreso,IDGrado")] Alumnos alumnos)
        {
            if (ModelState.IsValid)
            {
                db.Alumnos.Add(alumnos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDGrado = new SelectList(db.CGradoAlumnoes, "IDGrado", "GradoAlumno", alumnos.CGradoAlumno.IDGrado);
            return View(alumnos);
        }

        // GET: Alumnos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alumnos alumnos = db.Alumnos.Find(id);
            if (alumnos == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDGrado = new SelectList(db.CGradoAlumnoes, "IDGrado", "IDGrado", alumnos.IDGrado);
            return View(alumnos);
        }

        // POST: Alumnos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_alumno,NombreAlumno,ApelidoAlumno,DireccionAlumno,TelefonoAlumno,EmailAlumno,FechaIngreso,HoraIngreso,IDGrado")] Alumnos alumnos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alumnos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDGrado = new SelectList(db.CGradoAlumnoes, "IDGrado", "IDGrado", alumnos.IDGrado);
            return View(alumnos);
        }

        // GET: Alumnos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alumnos alumnos = db.Alumnos.Find(id);
            if (alumnos == null)
            {
                return HttpNotFound();
            }
            return View(alumnos);
        }

        // POST: Alumnos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Alumnos alumnos = db.Alumnos.Find(id);
            db.Alumnos.Remove(alumnos);
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
