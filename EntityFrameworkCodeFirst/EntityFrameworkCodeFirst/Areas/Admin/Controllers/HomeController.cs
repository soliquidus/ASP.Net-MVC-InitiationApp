using System.Web.Mvc;

namespace EntityFrameworkCodeFirst.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home/Index
        public ActionResult Index()
        {
            return View();
        }
    }
}