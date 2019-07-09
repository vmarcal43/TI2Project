using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
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
                return RedirectToAction("Index");
            }
            Estudios estudio = db.Estudios.Find(id);
            if (estudio == null)
            {
                return RedirectToAction("Index");
            }
            return View(estudio);
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
        public ActionResult Create([Bind(Include = "Nome")] Estudios estudio, HttpPostedFileBase foto)
        {

            string caminho = "";
            bool ficheiroValido = false;

            if (foto == null)
            {
                estudio.Imagem = "no_image.png";
            }
            else
            {
                string mimeType = foto.ContentType;

                if (mimeType == "image/jpeg" || mimeType == "image/png")
                {
                    Guid g;
                    g = Guid.NewGuid();

                    string extensao = Path.GetExtension(foto.FileName).ToLower();

                    string nomeFicheiro = g.ToString() + extensao;

                    caminho = Path.Combine(Server.MapPath("~/Images/Studios/"), nomeFicheiro);

                    estudio.Imagem = nomeFicheiro;

                    ficheiroValido = true;
                }
                else
                {
                    estudio.Imagem = "no_image.png";
                }
            }

            if (ModelState.IsValid)
            {

                try
                {
                    db.Estudios.Add(estudio);
                    db.SaveChanges();

                    if (ficheiroValido) foto.SaveAs(caminho);

                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    throw;
                }


               
              
            }

            return View(estudio);
        }

        // GET: Estudios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Estudios estudios = db.Estudios.Find(id);
            if (estudios == null)
            {
                return RedirectToAction("Index");
            }
            return View(estudios);
        }

        // POST: Estudios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome")] Estudios estudio, HttpPostedFileBase foto)
        {

            string caminho = "";
            bool ficheiroValido = false;

            if (foto == null)
            {
                estudio.Imagem = "no_image.png";
            }
            else
            {
                string mimeType = foto.ContentType;

                if (mimeType == "image/jpeg" || mimeType == "image/png")
                {
                    Guid g;
                    g = Guid.NewGuid();

                    string extensao = Path.GetExtension(foto.FileName).ToLower();

                    string nomeFicheiro = g.ToString() + extensao;

                    caminho = Path.Combine(Server.MapPath("~/Images/Studios/"), nomeFicheiro);

                    estudio.Imagem = nomeFicheiro;

                    ficheiroValido = true;
                }
                else
                {
                    estudio.Imagem = "no_image.png";
                }
            }

            if (ModelState.IsValid)
            {

                try
                {
                    db.Entry(estudio).State = EntityState.Modified;
                    db.SaveChanges();

                    if (ficheiroValido) foto.SaveAs(caminho);

                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    throw;
                }

                


            }
        return View(estudio);
        }

        // GET: Estudios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Estudios estudio = db.Estudios.Find(id);
            if (estudio == null)
            {
                return RedirectToAction("Index");
            }
            return View(estudio);
        }

        // POST: Estudios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Estudios estudio = db.Estudios.Find(id);
            db.Estudios.Remove(estudio);
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
