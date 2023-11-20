using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Company.DataLayer;
using EntityFrameworkCodeFirst.Filters;
using Company.DomainModels;

namespace EntityFrameworkCodeFirst.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class CategoriesController : Controller
    {
        // GET: Categories/Index
        public ActionResult Index()
        {
            CompanyDbContext db = new CompanyDbContext();
            List<Category> categories = db.Categories.ToList();
            return View(categories);
        }
    }
}