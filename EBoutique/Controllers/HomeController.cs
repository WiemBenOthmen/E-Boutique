using EBoutique.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EBoutique.Controllers
{
    public class HomeController : Controller
    {
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
    }
}