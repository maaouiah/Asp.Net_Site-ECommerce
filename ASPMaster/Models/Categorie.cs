using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASPMaster.Models
{
    public class Categorie
    {
        public int CategorieId { get; set; }
        [Required]
        [Display(Name = "Nom")]
        public string Nom { get; set; }

        [Required]
        [Display(Name = "Image")]
        public string Image { get; set; }

        public virtual ICollection<Produit> Produits { get; set; }
        
    }
}