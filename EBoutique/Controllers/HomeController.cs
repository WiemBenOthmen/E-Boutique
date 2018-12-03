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
        iBoutiqureDBEntities2 dc = new iBoutiqureDBEntities2();
        private static DbSet<Marque> lm;

        // GET: Home
        public ActionResult Index()
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

        //debut partie utilisateur
        public JsonResult GetUsers()
        {
            using (iBoutiqureDBEntities2 dc = new iBoutiqureDBEntities2())
            {
                var users = dc.Users.OrderBy(a => a.nom).ToList();
                return Json(new { data = users }, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpGet]
        public ActionResult Save(int id)
        {
            using (iBoutiqureDBEntities2 dc = new iBoutiqureDBEntities2())
            {   
                var u = dc.Users.Where(a => a.idUser == id).FirstOrDefault();
                return View(u);

            }
        }

        [HttpPost]
        public ActionResult Save(User us)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                using (iBoutiqureDBEntities2 dc = new iBoutiqureDBEntities2())
                {
                    if (us.idUser > 0)
                    {
                        //edit
                        var v = dc.Users.Where(a => a.idUser == us.idUser).FirstOrDefault();
                        if (v != null)
                        {
                            v.nom = us.nom;
                            v.prenom = us.prenom;
                            v.email = us.email;
                            v.tel = us.tel;
                            v.ville = us.ville;
                            v.adresse = us.adresse;
                            v.codePostal = us.codePostal;
                            v.datenaissance = us.datenaissance;
                        }
                    }
                    else
                    {
                        //save
                        dc.Users.Add(us);

                    }
                    dc.SaveChanges();
                    status = true;
                }
            }
            return RedirectToAction("ListeUsers", "home/ListeUsers");
                //new JsonResult { Data = new { status = status } };
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            using (iBoutiqureDBEntities2 dc = new iBoutiqureDBEntities2())
            {
                var v = dc.Users.Where(a => a.idUser == id).FirstOrDefault();
                if (v != null)
                {
                    return View(v);
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteUser(int id)
        {
            bool status = false;
            using (iBoutiqureDBEntities2 dc = new iBoutiqureDBEntities2())
            {
                var v = dc.Users.Where(a => a.idUser == id).FirstOrDefault();
                if (v != null)
                {
                    dc.Users.Remove(v);
                    dc.SaveChanges();
                    status = true;
                }
            }

            return new JsonResult { Data = new { status = status } };
        }

        //fin partie utilisateur


    }
}