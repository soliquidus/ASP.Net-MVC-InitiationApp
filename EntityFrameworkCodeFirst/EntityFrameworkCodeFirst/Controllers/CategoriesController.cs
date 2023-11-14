using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EntityFrameworkCodeFirst.Models;

namespace EntityFrameworkCodeFirst.Controllers
{
    public class CategoriesController : Controller
    {
        // GET
        public ActionResult Index()
        {
            CompanyDbContext db = new CompanyDbContext();
            List<Category> categories = db.Categories.ToList();
            return View(categories);
        }
    }
}