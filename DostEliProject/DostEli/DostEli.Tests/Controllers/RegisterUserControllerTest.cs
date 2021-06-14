using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Mvc;
using DostEli.Controllers;

namespace DostEli.Tests.Controllers
{
    [TestClass]
    public class RegisterUserControllerTest
    {
        [TestMethod]
        public void AddOrEditMessage()
        {
            RegisterUserController controller = new RegisterUserController();
            ViewResult result = controller.AddOrEdit() as ViewResult;
            Assert.AreEqual("Bu kullanıcı adını alamazsınız", result.ViewBag.DuplicateMessage);
            Assert.AreEqual("Kaydınız gerçekleştirildi. \nAramıza Hoşgeldiniz. \nLütfen Giriş Yapınız :)", result.ViewBag.SuccessMessage);

        }
    }
}
