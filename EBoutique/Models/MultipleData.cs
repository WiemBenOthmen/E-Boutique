using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EBoutique.Models;
namespace EBoutique.Models
{
    public class MultipleData
    {
        public IEnumerable<Commande> cmds { get; set; }
        public IEnumerable<Article> art { get; set; }
        public IEnumerable<LigneCommande> licmd { get; set; }
    }
}