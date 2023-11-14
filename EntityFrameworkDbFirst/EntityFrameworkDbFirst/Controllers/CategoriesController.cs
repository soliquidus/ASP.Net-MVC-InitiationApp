using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EntityFrameworkDbFirst.Models;

namespace EntityFrameworkDbFirst.Controllers
{
    public class CategoriesController : Controller
    {
        // GET
        public ActionResult Index()
        {
            EntityFrameworkDbFirstDBEntities db = new EntityFrameworkDbFirstDBEntities();
            List<Category> categories = db.Categories.ToList();
            return View(categories);
        }
    }
}