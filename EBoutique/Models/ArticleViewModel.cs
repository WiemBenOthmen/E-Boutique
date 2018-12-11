using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
namespace EBoutique.Models
{
    public class ArticleViewModel
    {
        public int idArticle { get; set; }
        public string refArticle { get; set; }
        public string libelleArticle { get; set; }
        public Nullable<double> prix { get; set; }
        public string description { get; set; }
        public Nullable<bool> disponibilite { get; set; }
        public Nullable<int> nbpieces { get; set; }
        public string couleur { get; set; }
        public string taille { get; set; }
       
        public string cheminImage { get; set; }
        public Nullable<int> idCategorie { get; set; }
        public Nullable<int> idType { get; set; }
        public Nullable<int> idMarque { get; set; }
        public Nullable<int> idAdmin { get; set; }
        public string libelleCatgorie { get; set; }
        public string libelleType { get; set; }
        public string libelleMarque { get; set; }
     
       



    }
}