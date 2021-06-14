using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DostEli.Models;

namespace DostEli.Controllers
{
    public class CalendarController : Controller
    {
        public ActionResult IndexCalendar()
        {
            return View();
        }
        public JsonResult GetEvents()
        {
            using (DostEliEntities dc = new DostEliEntities())
            {
                var events = dc.Event.ToList();
                return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

        [HttpPost]
        public JsonResult SaveEvent(Event e)
        {
            var status = false;
            using (DostEliEntities dc = new DostEliEntities())
            {
                if (e.EventID > 0)
                {
                    //Update the event
                    var v = dc.Event.Where(a => a.EventID == e.EventID).FirstOrDefault();
                    if (v != null)
                    {
                        v.Subject = e.Subject;
                        v.Start = e.Start;
                        v.End = e.End;
                        v.Description = e.Description;
                        v.IsFullDay = e.IsFullDay;
                        v.ThemeColor = e.ThemeColor;
                    }
                }
                else
                {
                    dc.Event.Add(e);
                }

                dc.SaveChanges();
                status = true;

            }
            return new JsonResult { Data = new { status = status } };
        }

        [HttpPost]
        public JsonResult DeleteEvent(int eventID)
        {
            var status = false;
            using (DostEliEntities dc = new DostEliEntities())
            {
                var v = dc.Event.Where(a => a.EventID == eventID).FirstOrDefault();
                if (v != null)
                {
                    dc.Event.Remove(v);
                    dc.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status } };
        }
    }
}