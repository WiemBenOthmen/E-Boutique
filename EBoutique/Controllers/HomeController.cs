using EBoutique.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace EBoutique.Controllers
{
    public class HomeController : Controller
    {
        iBoutiqureDBEntities dc = new iBoutiqureDBEntities();
        private static DbSet<Marque> lm;

        // GET: Home
        public ActionResult Index()
        {
            
            return View();

        }
        public ActionResult Admin()
        {
            return View();
        }
        public ActionResult ListeUsers()
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
            iBoutiqureDBEntities dc = new iBoutiqureDBEntities();
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
            iBoutiqureDBEntities dc = new iBoutiqureDBEntities();
            List<SelectListItem> ls = new List<SelectListItem>();
            lm =dc.Marques;
            foreach (var temp in lm)
            {
                ls.Add(new SelectListItem() { Text = temp.libelleMarque, Value = temp.idMarque.ToString() });
            }
            return ls;
        }

        public JsonResult GetUsers()
        {
            using (iBoutiqureDBEntities dc = new iBoutiqureDBEntities())
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


        /*public JsonResult GetArticleById(int AticleId)
        {
            Article model = dc.Articles.Where(x => x.AticleId == StudentId).SingleOrDefault();
            string value = string.Empty;
            value = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);
        }*/




    }
}