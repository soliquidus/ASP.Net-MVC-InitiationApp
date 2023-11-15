using System.Web.Mvc;
using EntityFrameworkCodeFirst.Filters;

namespace EntityFrameworkCodeFirst.Controllers
{
    public class HomeController : Controller
    {
        [ActionFilter]
        [ResultFilter]
        public ActionResult Index()
        {
            return View();
        }
    }
}