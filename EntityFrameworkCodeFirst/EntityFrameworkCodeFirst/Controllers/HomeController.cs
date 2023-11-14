using System.Web.Mvc;

namespace EntityFrameworkCodeFirst.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}