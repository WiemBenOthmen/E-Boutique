using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using EBoutique.Models;

namespace EBoutique.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        iBoutiqureDBEntities db = new iBoutiqureDBEntities();
        public ActionResult Registration()
        {
            return View();
        }
        public JsonResult SaveData(Admin model)
        {
            db.Admins.Add(model);
            db.SaveChanges();
            return Json("Registration avec succes",JsonRequestBehavior.AllowGet);
        }
    }
}