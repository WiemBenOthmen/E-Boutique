using EBoutique.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        public ActionResult ListeArticles()
        {
            // IEnumerable<Marque> marque = dc.Marques.ToList();
            var getmarqueslist = dc.Marques.ToList();
            SelectList l = new SelectList(getmarqueslist, "idMarque", "libelleMarque");
            ViewBag.liste = l;
            var getcategorielist = dc.Categories.ToList();
            SelectList l1 = new SelectList(getcategorielist, "idCategorie", "libelleCatgorie");
            ViewBag.liste1 = l1;

            var gettypelist = dc.Types.ToList();
            SelectList l2 = new SelectList(gettypelist, "idType", "libelleType");
            ViewBag.liste2 = l2;
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





        public JsonResult GetUsers()
        {
            using (iBoutiqureDBEntities2 dc = new iBoutiqureDBEntities2())
            {
                var users = dc.Users.OrderBy(a => a.nom).ToList();
                return Json(new { data = users }, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        public JsonResult SaveDataInDatabase(ArticleViewModel model)
        {
            var result = false;
            try
            {
                if (model.idArticle > 0)
                {
                    Article art = dc.Articles.SingleOrDefault(x => x.disponibilite == true && x.idArticle == model.idArticle);
                    art.description = model.description;
                    art.refArticle = model.refArticle;
                    art.libelleArticle = model.libelleArticle;
                    art.prix = model.prix;
                    art.nbpieces = model.nbpieces;
                    art.couleur = model.couleur;
                    art.taille = model.taille;
                    art.idCategorie = model.idCategorie;
                    art.idType = model.idType;
                    art.idMarque = model.idMarque;
                    dc.SaveChanges();
                    result = true;
                }
                else
                {
                    Article art = new Article();
                    art.description = model.description;
                    art.refArticle = model.refArticle;
                    art.libelleArticle = model.libelleArticle;
                    art.prix = model.prix;
                    art.nbpieces = model.nbpieces;
                    art.couleur = model.couleur;
                    art.taille = model.taille;
                    art.idCategorie = model.idCategorie;
                    art.idType = model.idType;
                    art.idMarque = model.idMarque;
                    art.disponibilite = false;
                    dc.Articles.Add(art);
                    dc.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }


        /* public JsonResult GetArticleById(int id_article)
         {
             Article model = dc.Articles.Where(x => x.idArticle == id_article).SingleOrDefault();
             string value = string.Empty;
             //  return Json(new { data = model }, JsonRequestBehavior.AllowGet);
             //
             //value =JsonConvert.
             value = JsonConvert.SerializeObject(model,  new JsonSerializerSettings
             {
                 ReferenceLoopHandling = ReferenceLoopHandling.Ignore
             });
             return Json(value, JsonRequestBehavior.AllowGet);
         }*/


    }
}