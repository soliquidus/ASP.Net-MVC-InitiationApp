using System.Web.Mvc;
using EntityFrameworkCodeFirst.Filters;

namespace EntityFrameworkCodeFirst.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class HomeController : Controller
    {
        // GET: Admin/Home/Index
        public ActionResult Index()
        {
            return View();
        }
    }
}