using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Company.DataLayer;
using Company.DomainModels;
using EntityFrameworkCodeFirst.Filters;

namespace EntityFrameworkCodeFirst.Controllers
{
    public class ProductsController : Controller
    {
        [AuthenticationFilter]
        [CustomerAuthorization]
        public ActionResult Index()
        {
            CompanyDbContext db = new CompanyDbContext();
            List<Product> products = db.Products.ToList();
            return View(products);
        }

        [ChildActionOnly]
        public ActionResult DisplaySingleProduct(Product p)
        {
            return PartialView("MyProduct", p);
        }
    }
}