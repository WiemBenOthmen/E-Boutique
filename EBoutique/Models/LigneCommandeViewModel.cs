using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EBoutique.Models

{
    using System;

    using System.Collections.Generic;

    public partial class LigneCommandeViewModel
    {
        public Nullable<int> idarticle { get; set; }
        public Nullable<int> idcommande { get; set; }
        public Nullable<decimal> qtecmde { get; set; }
        public int idlignecommande { get; set; }
        public string libelleArticle { get; set; }
        public string cheminImage { get; set; }
        public Nullable<double> prix { get; set; }
        public string descriptionCmd { get; set; }
        public int idUser { get;set; }


        //public virtual Article Article { get; set; }
        //public virtual Article Article1 { get; set; }
        // public virtual Commande Commande { get; set; }
    }
}