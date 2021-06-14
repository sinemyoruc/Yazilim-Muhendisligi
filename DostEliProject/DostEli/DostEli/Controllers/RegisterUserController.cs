using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DostEli.Models;

namespace DostEli.Controllers
{
    public class RegisterUserController : Controller
    {
        public ActionResult IndexKayit()
        {
            return View();
        }
        public ActionResult AddOrEdit(int id = 0)
        {
            Table_User user = new Table_User();
            return View(user);
        }
        [HttpPost]
        public ActionResult AddOrEdit(Table_User user)
        {
            using (DostEliEntities db = new DostEliEntities())
            {
                if (db.Table_User.Any(x => x.UserName == user.UserName))
                {
                    ViewBag.DuplicateMessage = "Bu kullanıcı adını alamazsınız";
                    return View("AddOrEdit", user);
                }
                else
                {
                    db.Table_User.Add(user);
                    db.SaveChanges();

                }
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Kaydınız gerçekleştirildi. \nAramıza Hoşgeldiniz. \nLütfen Giriş Yapınız :)";
            return View("AddOrEdit", new Table_User());
        }
    }
}