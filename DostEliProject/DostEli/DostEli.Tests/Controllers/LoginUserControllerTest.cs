using DostEli.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Mvc;

namespace DostEli.Tests.Controllers
{
    [TestClass]
    public class LoginUserControllerTest
    {
        [TestMethod]
        public void IndexLoginUserT()
        {
            var controller = new LoginUserController();
            var result = controller.IndexLoginUser() as ViewResult;
            Assert.AreEqual("IndexLoginUser", result.ViewName);
        }
    }
}
