using ASPMaster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPMaster.Helpes
{
    public class ListeCart
    {

        public List<Item> Items { get; private set; }

        public static readonly ListeCart Instance;

        static ListeCart()
        {

            if (HttpContext.Current.Session["MonpanierVirtuel"] == null)
            {

                Instance = new ListeCart();
                Instance.Items = new List<Item>();
                HttpContext.Current.Session["MonpanierVirtuel"] = Instance;

            }
            else
                Instance = (ListeCart)HttpContext.Current.Session["MonpanierVirtuel"];
        }

        protected ListeCart() { }

        public void AddItem(Produit prod)
        {

            Boolean iswhat = false;
            // Create a new item to add to the cart


            foreach (Item a in Items)
            {
                if (a.Prod.ProduitId == prod.ProduitId)
                {
                    a.quantite++;
                    iswhat = true;
                    return;
                }
            }
            if (iswhat == false)
            {

                Item newItem = new Item(prod);
                newItem.quantite = 1;
                Items.Add(newItem);
            }


        }

        public void setToNUll()
        {
            HttpContext.Current.Session["MonpanierVirtuel"] = null;
        }
        public void SetLessOneItem(Produit produit)
        {

            foreach (Item a in Items)
            {
                if (a.Prod.ProduitId == produit.ProduitId)
                {
                    if ( a.quantite <= 0  ){
                        RemoveItem(a.Prod);
                        return;
                    }
                    else
                    {
                        a.quantite--;
                        return;
                    }      

                }
            }

        }

        public void SetItemQuantity(Produit produit, int quantity)
        {

            if (quantity == 0)
            {
                RemoveItem(produit);
                return;
            }

            foreach (Item a in Items)
            {
                if (a.Prod.ProduitId == produit.ProduitId)
                {
                    a.quantite = quantity;
                    return;
                }
            }

        }

            

        public void RemoveItem(Produit produit)
        {

            Item t = null;

            foreach (Item a in Items)
            {

                if (a.Prod.ProduitId == produit.ProduitId)
                {
                    t = a;
                }
            }

            if (t != null)
            {
                Items.Remove(t);
            }

        }


        public float GetSubTotal()
        {
            float subTotal = 0;
            foreach (Item i in Items)
                subTotal += i.TotalPrice;
            return (float)subTotal;
        }

    }
}