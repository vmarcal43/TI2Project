using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TI2Project.Models;

namespace TI2Project.Controllers
{
    public class EstudiosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Estudios
        public ActionResult Index()
        {
            return View(db.Estudios.ToList());
        }

        // GET: Estudios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estudios estudios = db.Estudios.Find(id);
            if (estudios == null)
            {
                return HttpNotFound();
            }
            return View(estudios);
        }

        // GET: Estudios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Estudios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome,Imagem")] Estudios estudios)
        {
            if (ModelState.IsValid)
            {
                db.Estudios.Add(estudios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estudios);
        }

        // GET: Estudios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estudios estudios = db.Estudios.Find(id);
            if (estudios == null)
            {
                return HttpNotFound();
            }
            return View(estudios);
        }

        // POST: Estudios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,Imagem")] Estudios estudios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estudios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estudios);
        }

        // GET: Estudios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estudios estudios = db.Estudios.Find(id);
            if (estudios == null)
            {
                return HttpNotFound();
            }
            return View(estudios);
        }

        // POST: Estudios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Estudios estudios = db.Estudios.Find(id);
            db.Estudios.Remove(estudios);
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
