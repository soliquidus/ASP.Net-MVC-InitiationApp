using System.Web.Mvc;

namespace LayoutViewsInitiation.Controllers
{
    public class ProductsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        
        [Route("Products/Details/{id:int?}")]
        public ActionResult Details(int? id)
        {
            var products = new[] {
                new { ProductId = 1, ProductName = "iPhone", Cost = 80000  },
                new { ProductId = 2, ProductName = "Printer", Cost = 7500  },
                new { ProductId = 3, ProductName = "Camera", Cost = 14000 }
            };
            if (id == null)
            {
                return Content("Please pass any product id");
            }
            else
            {
                string prodName = "";
                foreach (var pro in products)
                {
                    if (pro.ProductId == id)
                    {
                        prodName = pro.ProductName;
                    }
                }
                return Content(prodName);
            }
        }
        
        [Route("Products/GetProductID/{productName}")]
        public ActionResult GetProductId(string id)
        {
            var products = new[] {
                new { ProductId = 1, ProductName = "iPhone", Cost = 80000  },
                new { ProductId = 2, ProductName = "Printer", Cost = 7500  },
                new { ProductId = 3, ProductName = "Camera", Cost = 14000 }
            };
            if (id == null)
            {
                return Content("Please pass any product name");
            }
            else
            {
                int prodId = 0;
                foreach (var pro in products)
                {
                    if (pro.ProductName == id)
                    {
                        prodId = pro.ProductId;
                    }
                }
                return Content(prodId.ToString());
            }
        }
    }
}