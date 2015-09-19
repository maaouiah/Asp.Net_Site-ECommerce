using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPMaster.Models
{
    public class Panier
    {
        public Panier()
        {
            //this.ListeCards = new HashSet<ListeCard>();
        }
        public int PanierId { get; set; }

        //[ScaffoldColumn(false)]
        public virtual ApplicationUser ApplicationUser { get; set; }

        // public virtual ICollection<ListeCard> ListeCards { get; set; }
    }
}