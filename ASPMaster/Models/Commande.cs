using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPMaster.Models
{
    public class Commande
    {
        public int CommandeId { get; set; }

        public int PanierId { get; set; }
        public virtual Panier Panier { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}
