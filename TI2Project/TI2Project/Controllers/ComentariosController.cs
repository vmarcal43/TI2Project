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
    public class ComentariosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Comentarios
        public async Task<ActionResult> Index()
        {
            var comentarios = db.Comentarios.Include(c => c.Filme);
            return View(await comentarios.ToListAsync());
        }

        // GET: Comentarios/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comentarios comentarios = await db.Comentarios.FindAsync(id);
            if (comentarios == null)
            {
                return HttpNotFound();
            }
            return View(comentarios);
        }

        // GET: Comentarios/Create
        public ActionResult Create()
        {
            ViewBag.FilmeFK = new SelectList(db.Filmes, "ID", "Titulo");
            return View();
        }

        // POST: Comentarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Conteudo,Data,FilmeFK")] Comentarios comentarios)
        {
            if (ModelState.IsValid)
            {
                db.Comentarios.Add(comentarios);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.FilmeFK = new SelectList(db.Filmes, "ID", "Titulo", comentarios.FilmeFK);
            return View(comentarios);
        }

        // GET: Comentarios/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comentarios comentarios = await db.Comentarios.FindAsync(id);
            if (comentarios == null)
            {
                return HttpNotFound();
            }
            ViewBag.FilmeFK = new SelectList(db.Filmes, "ID", "Titulo", comentarios.FilmeFK);
            return View(comentarios);
        }

        // POST: Comentarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Conteudo,Data,FilmeFK")] Comentarios comentarios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comentarios).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.FilmeFK = new SelectList(db.Filmes, "ID", "Titulo", comentarios.FilmeFK);
            return View(comentarios);
        }

        // GET: Comentarios/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comentarios comentarios = await db.Comentarios.FindAsync(id);
            if (comentarios == null)
            {
                return HttpNotFound();
            }
            return View(comentarios);
        }

        // POST: Comentarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Comentarios comentarios = await db.Comentarios.FindAsync(id);
            db.Comentarios.Remove(comentarios);
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
