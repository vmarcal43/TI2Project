﻿using System;
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
            // vars auxiliares
            string caminho = "";
            bool ficheiroValido = false;


            /// 1º será que foi enviado um ficheiro?
            if (foto == null)
            {
                // atribuir uma foto por defeito ao Agente
                ator.Foto = "no_image.png";
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
                    caminho = Path.Combine(Server.MapPath("~/Images/Actors/"), nomeFicheiro);

                    /// 4º como o associar ao novo Agente?
                    ator.Foto = nomeFicheiro;

                    // marcar o ficheiro como válido
                    ficheiroValido = true;
                }

                else
                {
                    // o ficheiro fornecido não é válido
                    // atribuo a imagem por defeito ao Agente
                    ator.Foto = "no_image.png";
                }


            }





            if (ModelState.IsValid)
            {
                try
                {
                    db.Atores.Add(ator);
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
        public ActionResult Edit([Bind(Include = "Nome,Nascimento,Nacionalidade")] Atores ator, HttpPostedFileBase foto)
        {
            // vars auxiliares
            string caminho = "";
            bool ficheiroValido = false;


            /// 1º será que foi enviado um ficheiro?
            if (foto == null)
            {
                // atribuir uma foto por defeito ao Agente
                ator.Foto = "no_image.png";
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
                    caminho = Path.Combine(Server.MapPath("~/Images/Actors/"), nomeFicheiro);

                    /// 4º como o associar ao novo Agente?
                    ator.Foto = nomeFicheiro;

                    // marcar o ficheiro como válido
                    ficheiroValido = true;
                }

                else
                {
                    // o ficheiro fornecido não é válido
                    // atribuo a imagem por defeito ao Agente
                    ator.Foto = "no_image.png";
                }


            }





            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(ator).State = EntityState.Modified;
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
