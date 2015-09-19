using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASPMaster.Models
{
    public class Type
    {
        public int TypeId { get; set; }

        [Required]
        [Display(Name = "Nom")]
        public string Nom { get; set; }

        public virtual ICollection<Produit> Produits { get; set; }
    }
}