using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EntityFrameworkCodeFirst.Models;

namespace EntityFrameworkCodeFirst.Controllers
{
    public class ProductsController : Controller
    {
        public ActionResult Index()
        {
            CompanyDbContext db = new CompanyDbContext();
            List<Product> products = db.Products.ToList();
            return View(products);
        }
    }
}