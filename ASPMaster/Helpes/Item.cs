using ASPMaster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPMaster.Helpes
{
    public class Item
    {

        public int quantite { get; set; }
        private int _ProduitId;

        public Produit _produit = null;
        public Produit Prod
        {
            get
            {

                return _produit;
            }
            set
            {
                _produit = value;
            }
        }

        public string Description
        {
            get { return _produit.Description; }
        }

        public float UnitPrice
        {
            get { return _produit.Prix; }
        }

        public float TotalPrice
        {
            get { 
  
                return _produit.Prix * quantite;
            }
        }

        public Item(Produit p)
        {
            this.Prod = p;
        }

        public bool Equals(Item item)
        {
            return item.Prod.ProduitId == this.Prod.ProduitId;
        }


    }
}