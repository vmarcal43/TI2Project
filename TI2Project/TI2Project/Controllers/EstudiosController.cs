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


            // vars auxiliares
            string caminho = "";
            bool ficheiroValido = false;


            /// 1º será que foi enviado um ficheiro?
            if (foto == null)
            {
                // atribuir uma foto por defeito ao Agente
                estudio.Imagem = "no_image.png";
            }

            else
            {
                /// 2º será que o ficheiro, se foi fornecido, é do tipo correto?
                string mimeType = foto.ContentType;
                if (mimeType == "image/jpeg" || mimeType == "image/png")
                {
                    // o ficheiro é do tipo correto

                    /// 3º qual o nome a atribuir ao ficheiro?
                    Guid g;
                    g = Guid.NewGuid(); // obtem os dados para o nome do ficheiro
                                        // e qual a extensão do ficheiro?
                    string extensao = Path.GetExtension(foto.FileName).ToLower();
                    // montar o novo nome
                    string nomeFicheiro = g.ToString() + extensao;
                    // onde guardar o ficheiro?
                    caminho = Path.Combine(Server.MapPath("~/Images/Studios/"), nomeFicheiro);

                    /// 4º como o associar ao novo Agente?
                    estudio.Imagem = nomeFicheiro;

                    // marcar o ficheiro como válido
                    ficheiroValido = true;
                }

                else
                {
                    // o ficheiro fornecido não é válido
                    // atribuo a imagem por defeito ao Agente
                    estudio.Imagem = "no_image.png";
                }


            }





            if (ModelState.IsValid)
            {

                try
                {
                    db.Estudios.Add(estudio);
                    db.SaveChanges();

                    /// 5º como o guardar no disco rígido? e onde?
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
            // vars auxiliares
            string caminho = "";
            bool ficheiroValido = false;


            /// 1º será que foi enviado um ficheiro?
            if (foto == null)
            {
                // atribuir uma foto por defeito ao Agente
                estudio.Imagem = "no_image.png";
            }

            else
            {
                /// 2º será que o ficheiro, se foi fornecido, é do tipo correto?
                string mimeType = foto.ContentType;
                if (mimeType == "image/jpeg" || mimeType == "image/png")
                {
                    // o ficheiro é do tipo correto

                    /// 3º qual o nome a atribuir ao ficheiro?
                    Guid g;
                    g = Guid.NewGuid(); // obtem os dados para o nome do ficheiro
                                        // e qual a extensão do ficheiro?
                    string extensao = Path.GetExtension(foto.FileName).ToLower();
                    // montar o novo nome
                    string nomeFicheiro = g.ToString() + extensao;
                    // onde guardar o ficheiro?
                    caminho = Path.Combine(Server.MapPath("~/Images/Studios/"), nomeFicheiro);

                    /// 4º como o associar ao novo Agente?
                    estudio.Imagem = nomeFicheiro;

                    // marcar o ficheiro como válido
                    ficheiroValido = true;
                }

                else
                {
                    // o ficheiro fornecido não é válido
                    // atribuo a imagem por defeito ao Agente
                    estudio.Imagem = "no_image.png";
                }


            }





            if (ModelState.IsValid)
            {

                try
                {
                    db.Entry(estudio).State = EntityState.Modified;
                    db.SaveChanges();

                    /// 5º como o guardar no disco rígido? e onde?
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
