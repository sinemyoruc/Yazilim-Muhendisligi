using DostEli.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Mvc;

namespace DostEli.Tests.Controllers
{
    [TestClass]
    public class VolunteerControllerTest
    {
        [TestMethod]
        public void IndexVolunteerView()
        {
            var controller = new VolunteerController();
            var result = controller.IndexVolunteer() as ViewResult;
            Assert.AreEqual("IndexVolunteer", result.ViewName);
        }
    }
}
