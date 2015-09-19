using ASPMaster.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ASPMaster.Controllers
{
    public class ProduitController : Controller
    {
        // GET: Produit
        private DataBase db = new DataBase();
      // GET: Produits
        public ViewResult Index()
        {
            var produits = db.Produits.Include(a => a.Categorie).Include(a => a.type);
            return View(produits.ToList());
        }
        // GET: Produits/lister
        public ActionResult Lister()
        {
            var produits = db.Produits.ToList();
            return View(produits);
        }
        // GET: Produits/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produit produits = await db.Produits.FindAsync(id);
            if (produits == null)
            {
                return HttpNotFound();
            }
            return View(produits);
        }

        // GET: Produits/Details/5
        public async Task<ActionResult> DetailsForUser(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produit produits = await db.Produits.FindAsync(id);
            if (produits == null)
            {
                return HttpNotFound();
            }
            return View(produits);
        }

        // GET: Produits/Create
        public ActionResult Create()
        {
            ViewBag.CategorieId = new SelectList(db.Categories, "CategorieId", "Nom");
            ViewBag.TypeId = new SelectList(db.Types, "TypeId", "Nom");
            return View();
        } 

        // POST: Produits/Create
        [HttpPost]
        public ActionResult Create(Produit Produit)
        {
            if (ModelState.IsValid)
            {
                db.Produits.Add(Produit);
                db.SaveChanges();
                return RedirectToAction("Lister");
            }

            ViewBag.CategorieId = new SelectList(db.Categories, "CategorieId", "Nom", Produit.CategorieId);
            ViewBag.TypeId = new SelectList(db.Types, "TypeId", "Nom", Produit.TypeId);
            return View(Produit);
        }

        // GET: /Produits/Edit/1
        public ActionResult Edit(int id)
        {
            Produit Produit = db.Produits.Find(id);
            ViewBag.CategorieId = new SelectList(db.Categories, "CategorieId","Nom", Produit.CategorieId);
            ViewBag.TypeId = new SelectList(db.Types, "TypeId","Nom", Produit.TypeId);
            return View(Produit);
        }

        // POST: /StoreManager/Edit/5
        [HttpPost]
        public ActionResult Edit(Produit Produit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Produit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Lister");
            }
            ViewBag.CategorieId = new SelectList(db.Categories, "CategorieId","Nom", Produit.CategorieId);
            ViewBag.TypeId = new SelectList(db.Types, "TypeId", "Nom", Produit.TypeId);
            return View(Produit);
        }

        // GET: Produits/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produit Produit = await db.Produits.FindAsync(id);
            if (Produit == null)
            {
                return HttpNotFound();
            }
            return View(Produit);
        }

        // POST: Produits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Produit Produit = await db.Produits.FindAsync(id);
            db.Produits.Remove(Produit);
            await db.SaveChangesAsync();
            return RedirectToAction("Lister");
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