using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DostEli.Models;

namespace DostEli.Controllers
{
    public class LoginManagerController : Controller
    {
        // GET: LoginManager
        DostEliEntities db = new DostEliEntities();
        public ActionResult IndexLoginManager()
        {
            return View();
        }
        [HttpPost]
        public ActionResult IndexLoginManager(Table_Manager managerModel)
        {

            var bilgiler = db.Table_Manager.FirstOrDefault(x => x.M_UserName == managerModel.M_UserName && x.M_Password == managerModel.M_Password);
            if (bilgiler != null)
            {
                return RedirectToAction("Index", "Match");
            }
            else
            {
                return View();
            }

        }
        public ActionResult LogOut()
        {
            int userId = (int)Session["Login_MId"];
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}