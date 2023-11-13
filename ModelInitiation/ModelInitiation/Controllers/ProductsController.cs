using System.Collections.Generic;
using System.Web.Mvc;
using ModelInitiation.Models;

namespace ModelInitiation.Controllers
{
    public class ProductsController : Controller
    {
        public ActionResult Index()
        {
            List<Product> products = new List<Product>()
            {
                new Product() { ProductId = 101, ProductName = "AC", Rate = 45000 },
                new Product() { ProductId = 102, ProductName = "Mobile", Rate = 38000 },
                new Product() { ProductId = 103, ProductName = "Bike", Rate = 94000 }
            };
            ViewBag.products = products;
            return View(products);
        }
        
        public ActionResult Details(int id)
        {
            List<Product> products = new List<Product>()
            {
                new Product() { ProductId = 101, ProductName = "AC", Rate = 45000 },
                new Product() { ProductId = 102, ProductName = "Mobile", Rate = 38000 },
                new Product() { ProductId = 103, ProductName = "Bike", Rate = 94000 }
            };
            Product matchingProduct = null;
            foreach (var item in products)
            {
                if (item.ProductId == id)
                {
                    matchingProduct = item;
                }
            }
            ViewBag.MatchingProduct = matchingProduct;
            return View(matchingProduct);
        }
        
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Create([Bind(Include = "ProductId, ProductName")] Product p)
        {
            return View();
        }

    }
    
}