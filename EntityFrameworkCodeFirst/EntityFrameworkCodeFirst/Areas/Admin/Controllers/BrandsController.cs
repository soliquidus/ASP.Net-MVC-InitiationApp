using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Company.DataLayer;
using EntityFrameworkCodeFirst.Filters;
using Company.DomainModels;

namespace EntityFrameworkCodeFirst.Areas.Admin.Controllers
{
    [AdminAuthorization]
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