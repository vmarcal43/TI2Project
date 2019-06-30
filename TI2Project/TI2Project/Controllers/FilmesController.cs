using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<ActionResult> Index()
        {
            var filmes = db.Filmes.Include(f => f.Estudio);
            return View(await filmes.ToListAsync());
        }

        // GET: Filmes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Filmes filmes = await db.Filmes.FindAsync(id);
            if (filmes == null)
            {
                return HttpNotFound();
            }
            return View(filmes);
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
        public async Task<ActionResult> Create([Bind(Include = "ID,Titulo,Imagem,Trailer,Lancamento,Genero,Duracao,EstudioFK")] Filmes filmes)
        {
            if (ModelState.IsValid)
            {
                db.Filmes.Add(filmes);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.EstudioFK = new SelectList(db.Estudios, "ID", "Nome", filmes.EstudioFK);
            return View(filmes);
        }

        // GET: Filmes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Filmes filmes = await db.Filmes.FindAsync(id);
            if (filmes == null)
            {
                return HttpNotFound();
            }
            ViewBag.EstudioFK = new SelectList(db.Estudios, "ID", "Nome", filmes.EstudioFK);
            return View(filmes);
        }

        // POST: Filmes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Titulo,Imagem,Trailer,Lancamento,Genero,Duracao,EstudioFK")] Filmes filmes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(filmes).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.EstudioFK = new SelectList(db.Estudios, "ID", "Nome", filmes.EstudioFK);
            return View(filmes);
        }

        // GET: Filmes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Filmes filmes = await db.Filmes.FindAsync(id);
            if (filmes == null)
            {
                return HttpNotFound();
            }
            return View(filmes);
        }

        // POST: Filmes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Filmes filmes = await db.Filmes.FindAsync(id);
            db.Filmes.Remove(filmes);
            await db.SaveChangesAsync();
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
