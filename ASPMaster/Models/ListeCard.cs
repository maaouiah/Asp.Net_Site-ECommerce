using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ASPMaster.Models
{
    public class ListeCard
    {

        public int ListeCardId { get; set; }

        public int PanierId { get; set; }
        public virtual Panier Panier { get; set; }

        public int ProduitId { get; set; }
        public virtual Produit Produit { get; set; }

        public int Quatite { get; set; }
        public float PrixTotal { get; set; }

        public ListeCard(Panier p, Produit pp, int q, float prix)
        {
            this.Panier = p;
            this.Produit = pp;
            this.Quatite = q;
            this.PrixTotal = prix; 
        }

    }
}
