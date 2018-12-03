using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EBoutique.Models
{
    public class CommandeViewModel
    {
        public int idCommande { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public string adresseLivraison { get; set; }
        public string detailLivraison { get; set; }
        public Nullable<System.DateTime> dateLivraison { get; set; }
    }
}