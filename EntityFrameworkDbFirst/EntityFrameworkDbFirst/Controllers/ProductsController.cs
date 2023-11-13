using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EntityFrameworkDbFirst.Models;

namespace EntityFrameworkDbFirst.Controllers
{
    public class ProductsController : Controller
    {
        // GET
        public ActionResult Index()
        {
            EntityFrameworkDbFirstDBEntities db = new EntityFrameworkDbFirstDBEntities();
            List<Product> products = db.Products.ToList();
            return View(products);
        }
    }
}