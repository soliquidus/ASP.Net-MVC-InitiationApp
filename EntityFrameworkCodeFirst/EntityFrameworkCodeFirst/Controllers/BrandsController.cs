using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EntityFrameworkCodeFirst.Models;

namespace EntityFrameworkCodeFirst.Controllers
{
    public class BrandsController : Controller
    {
        public ActionResult Index()
        {
            CompanyDbContext db = new CompanyDbContext();
            List<Brand> brands = db.Brands.ToList();
            return View(brands);
        }
    }
}