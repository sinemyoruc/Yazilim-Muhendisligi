using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DostEli.Models;

namespace DostEli.Controllers
{
    public class LoginUserController : Controller
    {
        // GET: LoginUser
        DostEliEntities db = new DostEliEntities();
        public ActionResult IndexLoginUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult IndexLoginUser(Table_User userModel)
        {
            var bilgiler = db.Table_User.Where(x => x.UserName == userModel.UserName && x.Password == userModel.Password).FirstOrDefault();
            if (bilgiler == null)
            {
                ViewBag.ErrorMessage = "Kullancı adı veya parola hatalı";
                return View("IndexLoginUser", userModel);
            }
            else
            {
                Session["userID"] = userModel.User_Id;
                Session["userFirstName"] = userModel.UserFirstName;
                return RedirectToAction("IndexUser", "User");

            }
        }

        public ActionResult LogOut()
        {
            int userID = (int)Session["userID"];
            Session.Abandon();
            return RedirectToAction("IndexLoginUser", "LoginUser");
        }
    }
}