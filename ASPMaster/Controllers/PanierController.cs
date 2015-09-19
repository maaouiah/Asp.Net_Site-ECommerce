using ASPMaster.Helpes;
using ASPMaster.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Data.Entity;


namespace ASPMaster.Controllers
{
    [Authorize]
    public class PanierController : Controller
    {
        DataBase db = new DataBase();
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;


        public PanierController()
        {
        }

        public PanierController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set 
            { 
                _signInManager = value; 
            }
        }


        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            ViewBag.Liste = ListeCart.Instance.Items;
            ViewBag.total = ListeCart.Instance.GetSubTotal();
            return View();

        }

        [AllowAnonymous]
        public ActionResult AjouterProduit(int? id )
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Produit pp = db.Produits.Find(id);


            ListeCart.Instance.AddItem(pp);
            ViewBag.Liste = ListeCart.Instance.Items;
            ViewBag.total = ListeCart.Instance.GetSubTotal();
            return View();

        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult PlusProduit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Produit pp = db.Produits.Find(id);
            ListeCart.Instance.AddItem(pp);
            Item trouve = null;

            foreach (Item a in ListeCart.Instance.Items)
            {
                if (a.Prod.ProduitId == pp.ProduitId)
                    trouve = a;
            }

            var results = new {
                                ct = 1  ,
                                Total = ListeCart.Instance.GetSubTotal () ,
                                Quatite = trouve.quantite ,
                                TotalRow = trouve.TotalPrice 
                                };
            return Json(results) ;
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult MoinsProduit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Produit pp = db.Produits.Find(id);
            ListeCart.Instance.SetLessOneItem(pp);
            Item trouve = null;

            foreach (Item a in ListeCart.Instance.Items)
            {
                if (a.Prod.ProduitId == pp.ProduitId)
                    trouve = a;
            }



            if (trouve != null)
            {
                var results = new
                {
                    
                    Total = ListeCart.Instance.GetSubTotal(),
                    Quatite = trouve.quantite,
                    TotalRow = trouve.TotalPrice,
                    ct = 1 
                };

                return Json(results);

            }
            else
            {
                var results = new
                {
                        ct = 0 
                };

                return Json(results);
            }
            return null;
            

        }

        public ActionResult CheckOut()
        {

            return View();
        }

        [HttpPost]
        public ActionResult CheckOut(FormCollection collection)
        {
            
            
            /*
            Panier p = new Panier();
 
            p.ApplicationUser = db.Users.Find( User.Identity.GetUserId() ) ;

            db.Paniers.Add(p);
            db.SaveChanges();

            Commande c = new Commande();
            c.Panier = p;
            p.ApplicationUser = db.Users.Find(User.Identity.GetUserId());
            db.Commandes.Add(c);
            db.SaveChanges();


            foreach (Item a in ListeCart.Instance.Items)
            {
                db.ListeCards.Add(new ListeCard(p, a.Prod, a.quantite, a.TotalPrice));
                db.SaveChanges();
            
            }
       
            **/



            ListeCart.Instance.Items.Clear();

                ViewBag.Message = "Commande effectuée zvec succès";

            return View();

        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult SupprimerProduit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Produit pp = db.Produits.Find(id);
            ListeCart.Instance.RemoveItem(pp);
            var results = new
            {
                Total = ListeCart.Instance.GetSubTotal(),
            };

            return Json(results);
        }
    }
}