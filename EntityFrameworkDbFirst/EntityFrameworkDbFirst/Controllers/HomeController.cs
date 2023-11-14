using System.Web.Mvc;

namespace EntityFrameworkDbFirst.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}