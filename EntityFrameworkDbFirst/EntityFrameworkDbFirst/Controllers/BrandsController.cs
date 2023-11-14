using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EntityFrameworkDbFirst.Models;

namespace EntityFrameworkDbFirst.Controllers
{
    public class BrandsController : Controller
    {
        public ActionResult Index()
        {
            EntityFrameworkDbFirstDBEntities db = new EntityFrameworkDbFirstDBEntities();
            List<Brand> brands = db.Brands.ToList();
            return View(brands);
        }
    }
}