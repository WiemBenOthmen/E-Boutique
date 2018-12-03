using EBoutique.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EBoutique.Models;
using System.Data.Entity.Core.Objects;

namespace EBoutique.Controllers
{
    public class HomeController : Controller
    {
        iBoutiqureDBEntities2 dc = new iBoutiqureDBEntities2();
        private static DbSet<Marque> lm;

        // GET: Home
        public ActionResult Index()
        {
            
            return View();

        }
        public ActionResult User()
        {
            return View();
        }
        public ActionResult Tables()
        {
            // IEnumerable<Marque> marque = dc.Marques.ToList();
            var getmarqueslist = dc.Marques.ToList();
            SelectList l = new SelectList(getmarqueslist, "idMarque", "libelleMarque");
            ViewBag.liste = l;
            return View();
        }
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult Panier()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Categories()
        {
            return View();
        }
        public ActionResult Single()
        {
            return View();
        }
        public JsonResult GetArticles()
        {
            iBoutiqureDBEntities2 dc = new iBoutiqureDBEntities2();
            List<ArticleViewModel> articles = dc.Articles.Select(x => new ArticleViewModel
            {
                idArticle = x.idArticle,
                refArticle = x.refArticle,
                libelleArticle = x.libelleArticle,
                prix = x.prix,
                description = x.description,
                disponibilite = x.disponibilite,
                nbpieces = x.nbpieces,
                libelleMarque = x.Marque.libelleMarque,
                libelleType = x.Type.libelleType,
                libelleCatgorie = x.Categorie.libelleCatgorie,
                couleur = x.couleur,
                taille = x.taille
            }
            ).ToList();

            return Json(new { data = articles }, JsonRequestBehavior.AllowGet);
        }
        public static List<SelectListItem> GetDropDown()
        {
            iBoutiqureDBEntities2 dc = new iBoutiqureDBEntities2();
            List<SelectListItem> ls = new List<SelectListItem>();
            lm =dc.Marques;
            foreach (var temp in lm)
            {
                ls.Add(new SelectListItem() { Text = temp.libelleMarque, Value = temp.idMarque.ToString() });
            }
            return ls;
        }

        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Commande()
        {
            iBoutiqureDBEntities2 db = new iBoutiqureDBEntities2();
            return View(db.fundisplay());
        }

        [HttpPost]
        public ActionResult DeleteCmd(int id)
        {
            using (iBoutiqureDBEntities2 db = new iBoutiqureDBEntities2())
            {


            {
                Commande cmd = db.Commandes.Where(x => x.idCommande == id).FirstOrDefault<Commande>();
                db.Commandes.Remove(cmd);
                db.SaveChanges();
                return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
        






        //Commande cmd = db.Commandes.Where(x => x.idCommande == id).FirstOrDefault<Commande>();

        //iBoutiqureDBEntities2 db = new iBoutiqureDBEntities2();
        // var cmd=db.supprimer(id);

        //return Ok(cmd);
    }
        }

        //private ActionResult Ok(ObjectResult<Commande> cmd)
        //{
        //    throw new NotImplementedException();
        //    ;
        //}
        

        


    }
}