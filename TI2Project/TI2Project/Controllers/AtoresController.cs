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
    public class AtoresController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Atores
        public ActionResult Index()
        {
            return View(db.Atores.ToList());
        }

        // GET: Atores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Atores ator = db.Atores.Find(id);
            if (ator == null)
            {
                return RedirectToAction("Index");
            }
            return View(ator);
        }

        // GET: Atores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Atores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nome,Nascimento,Nacionalidade")] Atores ator, HttpPostedFileBase foto)
        {
            //variáveis auxiliares
            string caminho = "";
            bool ficheiroValido = false;

            //verifica se foi escolhida alguma imagem
            if (foto == null)
            {
                //atribui uma imagem em branco por defeito
                ator.Foto = "no_image.png";
            }
            else
            {
                string mimeType = foto.ContentType; //identificar o tipo de ficheiro

                //verifica se o ficheiro é jpg ou png
                if (mimeType == "image/jpeg" || mimeType == "image/png")
                {
                    Guid g;
                    g = Guid.NewGuid(); // obtem os dados para o nome do ficheiro

                    string extensao = Path.GetExtension(foto.FileName).ToLower(); //extensão do ficheiro

                    string nomeFicheiro = g.ToString() + extensao; // criar o nome do ficheiro

                    caminho = Path.Combine(Server.MapPath("~/Images/Actors/"), nomeFicheiro); //guarda o caminho do ficheiro

                    ator.Foto = nomeFicheiro;  //atribuir o nome do ficheiro à imagem do filme

                    ficheiroValido = true; //o ficheiro é válido
                }
                else
                {
                    ator.Foto = "no_image.png";
                }
            }
            if (ModelState.IsValid)
            {
                try
                {
                    db.Atores.Add(ator);
                    db.SaveChanges();

                    if (ficheiroValido) foto.SaveAs(caminho); //se o ficheiro for válido guarda a imagem

                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    throw;
                }

            }

            return View(ator);
        }

        // GET: Atores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Atores ator = db.Atores.Find(id);
            if (ator == null)
            {
                return RedirectToAction("Index");
            }
            return View(ator);
        }

        // POST: Atores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,Nascimento,Nacionalidade")] Atores ator, HttpPostedFileBase foto)
        {
            string caminho = "";
            bool ficheiroValido = false;

            if (foto == null)
            {
                ator.Foto = "no_image.png";
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

                    caminho = Path.Combine(Server.MapPath("~/Images/Actors/"), nomeFicheiro);

                    ator.Foto = nomeFicheiro;

                    ficheiroValido = true;
                }
                else
                {
                    ator.Foto = "no_image.png";
                }
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(ator).State = EntityState.Modified;
                    db.SaveChanges();

                    if (ficheiroValido) foto.SaveAs(caminho);

                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    throw;
                }

            }
            return View(ator);
        }

        // GET: Atores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Atores ator = db.Atores.Find(id);
            if (ator == null)
            {
                return RedirectToAction("Index");
            }
            return View(ator);
        }

        // POST: Atores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Atores ator = db.Atores.Find(id);
            db.Atores.Remove(ator);
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
