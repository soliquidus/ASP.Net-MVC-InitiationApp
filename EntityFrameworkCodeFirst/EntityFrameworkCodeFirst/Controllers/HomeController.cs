using System.Web.Mvc;
using EntityFrameworkCodeFirst.Filters;

namespace EntityFrameworkCodeFirst.Controllers
{
    public class HomeController : Controller
    {
        [ActionFilter]
        [ResultFilter]
        [OutputCache(Duration = 60)]
        public ActionResult Index()
        {
            return View();
        }
    }
}