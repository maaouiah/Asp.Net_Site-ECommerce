using ASPMaster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPMaster.Controllers
{
    public class HomeController : Controller
    {
        private DataBase db = new DataBase();
        // GET: /Home/
        public ActionResult Index()
        {
            var produits = db.Produits.ToList();
            return View(produits);
        }

        public ActionResult listerCategorie()
        {
            var Catg = db.Categories.ToList();
            return View(Catg); ;
        }

        public ActionResult listerProduitCategorie(string categorie)
        {
            var produitListe = db.Categories.Include("Produits")
                .Single(g => g.Nom == categorie);

            return View(produitListe);
        }


        public ActionResult listerType()
        {
            var type = db.Types.ToList();
            return View(type); ;
        }

        public ActionResult listerProduitType(string type)
        {
            var produitListe = db.Types.Include("Produits")
                .Single(g => g.Nom == type);

            return View(produitListe);
        }
    }
}