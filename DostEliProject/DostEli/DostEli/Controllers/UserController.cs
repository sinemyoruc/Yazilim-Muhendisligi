using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DostEli.Models;

namespace DostEli.Controllers
{
    public class UserController : Controller
    {
        // GET: Product
        public ActionResult IndexUser()
        {
            ProductModel product = new ProductModel();
            using (DostEliEntities db = new DostEliEntities())
            {
                product.Products = db.Table_Product.ToList<Table_Product>();
            }
            return View(product);
        }
        //[HttpPost]
        public ActionResult Index2(ProductModel model)
        {
            var selectedProduct = model.Products.Where(x => x.IsChecked == true).ToList<Table_Product>();
            return Content(String.Join("<br>", selectedProduct.Select(x => x.ProductName)));
        }
    }
}