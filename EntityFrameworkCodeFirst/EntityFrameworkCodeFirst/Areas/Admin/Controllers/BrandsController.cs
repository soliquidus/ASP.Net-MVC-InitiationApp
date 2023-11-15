using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EntityFrameworkCodeFirst.Models;

namespace EntityFrameworkCodeFirst.Areas.Admin.Controllers
{
    public class BrandsController : Controller
    {
        // GET: Brands/Index
        public ActionResult Index()
        {
            CompanyDbContext db = new CompanyDbContext();
            List<Brand> brands = db.Brands.ToList();
            return View(brands);
        }
    }
}