using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCProduct.Models;

namespace MVCProduct.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            var product = GetProductsDetails();



            return View(product);
        }



        public IEnumerable<Product> GetProductsDetails()
        {
            return new List<Product>
            {
                new Product{ProductId=101 ,ProductName="AC",Rate=45000},
                new Product{ProductId=102 ,ProductName="Mobile",Rate=38000},
                new Product{ProductId=103 ,ProductName="Bike",Rate=94000}
            };
        }
        public ActionResult Details(int id)
        {

            var product = GetProductsDetails().SingleOrDefault(c => c.ProductId == id);
            if (product == null)
                return HttpNotFound();
            return View(product);
        }
    }
}