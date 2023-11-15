using System.Web.Mvc;

namespace EntityFrameworkCodeFirst.Areas.Manager.Controllers
{
    public class HomeController : Controller
    {
        // GET
        public ActionResult Index()
        {
            return View();
        }
    }
}