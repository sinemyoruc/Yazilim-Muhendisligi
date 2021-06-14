using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DostEli.Models;

namespace DostEli.Controllers
{
    public class VolunteerController : Controller
    {
        // GET: Volunteer
        public ActionResult IndexVolunteer()
        {
            MatchModel Mmodel = new MatchModel();
            using (DostEliEntities db = new DostEliEntities())
            {
                Mmodel.match = db.Table_Match.ToList<Table_Match>();
            }
            return View(Mmodel);
        }
    }
}