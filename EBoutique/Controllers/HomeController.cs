using EBoutique.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Data.Entity.Core.Objects;
using System.IO;

namespace EBoutique.Controllers
{
    public class HomeController : Controller
    {
        iBoutiqureDBEntities4 dc = new iBoutiqureDBEntities4();
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
            iBoutiqureDBEntities4 dc = new iBoutiqureDBEntities4();
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
            iBoutiqureDBEntities4 dc = new iBoutiqureDBEntities4();
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
        public ActionResult RegisterAdmin()
        {
            return View();
        }
        [HttpPost]

        public ActionResult RegisterAdmin(Admin admin)
        {
            iBoutiqureDBEntities4 db = new iBoutiqureDBEntities4();
            //var userloggedIn = db.Users.SingleOrDefault(x => x.login == admin.login && x.mdp == admin.mdp);
            //if(userloggedIn !=null)
            //{
            //    ViewBag.massage = "Vous etes connecté";
            //    ViewBag.triedOnce = "yes";
            return RedirectToAction("index", "home/index");

            //else
            //{
            //    ViewBag.triedOnce = "yes";
            //    return View();
            //}

        }
        public ActionResult LoginAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginAdmin(Admin admin)
        {
            iBoutiqureDBEntities4 db = new iBoutiqureDBEntities4();
            db.Admins.Add(admin);
            db.SaveChanges();
            ViewBag.message = "connexion avec succes";
            return View();
        }


        public ActionResult Commande()
        {
            iBoutiqureDBEntities4 db = new iBoutiqureDBEntities4();
            return View(db.fun_display1());
        }

        [HttpPost]
        public ActionResult Deletem(int id)
        {
            using (iBoutiqureDBEntities4 db = new iBoutiqureDBEntities4())
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





       
        [HttpPost]
        public JsonResult SaveDataInDatabase(ArticleViewModel model)
        {
            var result = false;
            try
            {
                /*string fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
                string extension = Path.GetExtension(model.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                model.cheminImage = "~/Images/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
                model.ImageFile.SaveAs(fileName);
                ModelState.Clear();*/

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
                   // art.cheminImage = model.cheminImage;
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


         public JsonResult GetArticleById(int id_article)
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
         }

        //debut partie utilisateur
        public JsonResult GetUsers()
        {
            using (iBoutiqureDBEntities4 dc = new iBoutiqureDBEntities4())
            {
                var users = dc.Users.OrderBy(a => a.nom).ToList();
                return Json(new { data = users }, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpGet]
        public ActionResult Save(int id)
        {
            using (iBoutiqureDBEntities4 dc = new iBoutiqureDBEntities4())
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
                using (iBoutiqureDBEntities4 dc = new iBoutiqureDBEntities4())
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
            using (iBoutiqureDBEntities4 dc = new iBoutiqureDBEntities4())
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
            using (iBoutiqureDBEntities4 dc = new iBoutiqureDBEntities4())
            {
                var v = dc.Users.Where(a => a.idUser == id).FirstOrDefault();
                if (v != null)
                {
                    dc.Users.Remove(v);
                    dc.SaveChanges();
                    status = true;
                }
            }
            return RedirectToAction("ListeUsers", "home/ListeUsers");
            // return new JsonResult { Data = new { status = status } };
        }

        //fin partie utilisateur
        public ActionResult ChatBot(String attr)
        {
            ChatBotC bot = new ChatBotC();
          String res= bot.reponseQuestion(attr);
            //res = "<p>" + res + " </p><br>";
            
            return Content(res, "text/html");
        }

    }
}