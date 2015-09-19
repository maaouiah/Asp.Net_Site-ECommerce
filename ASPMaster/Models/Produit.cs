using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASPMaster.Models
{

    public partial class Produit
    {

        public int ProduitId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Nom { get; set; }

        [Display(Name = "Description :")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Prix en € :")]
        public float Prix { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date d'ajout")]
        public DateTime? DateAjout { get; set; }

        [Required(ErrorMessage = "Erreur categorie !")]
        [Display(Name = "Catégorie")]
        public int CategorieId { get; set; }
        public virtual Categorie Categorie { get; set; }

        [Required(ErrorMessage = "Erreur Type !")]
        [Display(Name = "Type")]
        public int TypeId { get; set; }
        public virtual Type type  { get; set; }

        [Required]
        [Display(Name = "Quantité en unité :")]
        public int Quantite { get; set; }

        [Required]
        [Display(Name = "Image :")]
        public string Image { get; set; }

        // public virtual ICollection<ListeCard> ListeCards { get; set; }


    }
}