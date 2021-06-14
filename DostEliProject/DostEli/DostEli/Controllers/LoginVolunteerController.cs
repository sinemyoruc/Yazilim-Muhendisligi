using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DostEli.Models;

namespace DostEli.Controllers
{
    public class LoginVolunteerController : Controller
    {
        // GET: LoginVolunteer
        DostEliEntities db = new DostEliEntities();
        public ActionResult IndexLoginVolunteer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult IndexLoginVolunteer(Table_Volunteer volunteerModel)
        {
            var bilgiler = db.Table_Volunteer.FirstOrDefault(x => x.V_UserName == volunteerModel.V_UserName && x.V_Password == volunteerModel.V_Password);
            if (bilgiler != null)
            {
                return RedirectToAction("IndexVolunteer", "Volunteer");
            }
            else
            {
                return View();
            }
        }
        public ActionResult LogOut()
        {
            int userId = (int)Session["Login_Id"];
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
        public ActionResult EslesmeListele()
        {

            return View();
        }
    }
}