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
    public class AtoresFilmesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AtoresFilmes
        public async Task<ActionResult> Index()
        {
            var atoresFilmes = db.AtoresFilmes.Include(a => a.Ator).Include(a => a.Filme);
            return View(await atoresFilmes.ToListAsync());
        }

        // GET: AtoresFilmes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AtoresFilmes atoresFilmes = await db.AtoresFilmes.FindAsync(id);
            if (atoresFilmes == null)
            {
                return HttpNotFound();
            }
            return View(atoresFilmes);
        }

        // GET: AtoresFilmes/Create
        public ActionResult Create()
        {
            ViewBag.AtorFK = new SelectList(db.Atores, "ID", "Nome");
            ViewBag.FilmeFK = new SelectList(db.Filmes, "ID", "Titulo");
            return View();
        }

        // POST: AtoresFilmes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,NomePersonagem,AtorFK,FilmeFK")] AtoresFilmes atoresFilmes)
        {
            if (ModelState.IsValid)
            {
                db.AtoresFilmes.Add(atoresFilmes);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.AtorFK = new SelectList(db.Atores, "ID", "Nome", atoresFilmes.AtorFK);
            ViewBag.FilmeFK = new SelectList(db.Filmes, "ID", "Titulo", atoresFilmes.FilmeFK);
            return View(atoresFilmes);
        }

        // GET: AtoresFilmes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AtoresFilmes atoresFilmes = await db.AtoresFilmes.FindAsync(id);
            if (atoresFilmes == null)
            {
                return HttpNotFound();
            }
            ViewBag.AtorFK = new SelectList(db.Atores, "ID", "Nome", atoresFilmes.AtorFK);
            ViewBag.FilmeFK = new SelectList(db.Filmes, "ID", "Titulo", atoresFilmes.FilmeFK);
            return View(atoresFilmes);
        }

        // POST: AtoresFilmes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,NomePersonagem,AtorFK,FilmeFK")] AtoresFilmes atoresFilmes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(atoresFilmes).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.AtorFK = new SelectList(db.Atores, "ID", "Nome", atoresFilmes.AtorFK);
            ViewBag.FilmeFK = new SelectList(db.Filmes, "ID", "Titulo", atoresFilmes.FilmeFK);
            return View(atoresFilmes);
        }

        // GET: AtoresFilmes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AtoresFilmes atoresFilmes = await db.AtoresFilmes.FindAsync(id);
            if (atoresFilmes == null)
            {
                return HttpNotFound();
            }
            return View(atoresFilmes);
        }

        // POST: AtoresFilmes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            AtoresFilmes atoresFilmes = await db.AtoresFilmes.FindAsync(id);
            db.AtoresFilmes.Remove(atoresFilmes);
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
