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
    public class FilmesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Filmes
        public ActionResult Index()
        {
            var filme = db.Filmes.Include(f => f.Estudio);
            return View(filme.ToList());
        }

        // GET: Filmes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Filmes filme = db.Filmes.Find(id);
            if (filme == null)
            {
                return RedirectToAction("Index");
            }
            return View(filme);
        }

        // GET: Filmes/Create
        public ActionResult Create()
        {
            ViewBag.EstudioFK = new SelectList(db.Estudios, "ID", "Nome");
            return View();
        }

        // POST: Filmes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Titulo,Trailer,Lancamento,Genero,Duracao,EstudioFK")] Filmes filme, HttpPostedFileBase foto)
        {
            //variáveis auxiliares
            string caminho = "";
            bool ficheiroValido = false;

            //verifica se foi escolhida alguma imagem
            if (foto == null)
            {
                //atribui uma imagem em branco por defeito
                filme.Imagem = "no_image.png";
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

                    caminho = Path.Combine(Server.MapPath("~/Images/Films/"), nomeFicheiro); //guarda o caminho do ficheiro

                    filme.Imagem = nomeFicheiro; //atribuir o nome do ficheiro à imagem do filme

                    ficheiroValido = true; //o ficheiro é válido
                }
                else
                {
                    filme.Imagem = "no_image.png";
                }
            }
            if (ModelState.IsValid)
            {
                try
                {
                    db.Filmes.Add(filme);
                    db.SaveChanges();

                    if (ficheiroValido) foto.SaveAs(caminho); //se o ficheiro for válido guarda a imagem

                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    throw;
                }

            }
            

            ViewBag.EstudioFK = new SelectList(db.Estudios, "ID", "Nome", filme.EstudioFK);
            return View(filme);
        }

        // GET: Filmes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Filmes filmes = db.Filmes.Find(id);
            if (filmes == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.EstudioFK = new SelectList(db.Estudios, "ID", "Nome", filmes.EstudioFK);
            return View(filmes);
        }

        // POST: Filmes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Titulo,Trailer,Lancamento,Genero,Duracao,EstudioFK")] Filmes filme, HttpPostedFileBase foto)
        {
            string caminho = "";
            bool ficheiroValido = false;

            if (foto == null)
            {
                filme.Imagem = "no_image.png";
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

                    caminho = Path.Combine(Server.MapPath("~/Images/Films/"), nomeFicheiro);

                    filme.Imagem = nomeFicheiro;

                    ficheiroValido = true;
                }
                else
                {
                    filme.Imagem = "no_image.png";
                }
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(filme).State = EntityState.Modified;
                    db.SaveChanges();

                    if (ficheiroValido) foto.SaveAs(caminho);

                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    throw;
                }

            }


            ViewBag.EstudioFK = new SelectList(db.Estudios, "ID", "Nome", filme.EstudioFK);
            return View(filme);
        }

        // GET: Filmes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Filmes filme = db.Filmes.Find(id);
            if (filme == null)
            {
                return RedirectToAction("Index");
            }
            return View(filme);
        }

        // POST: Filmes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Filmes filme = db.Filmes.Find(id);
            db.Filmes.Remove(filme);
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
