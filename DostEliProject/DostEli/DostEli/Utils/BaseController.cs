using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DostEli.Models;

namespace DostEli.Utils
{
    public class BaseController : Controller
    {
        // GET: Base
        public DostEliEntities db = new DostEliEntities();
        public string UserCode { get; set; }
        public string NameSurname { get; set; }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }
    }
}