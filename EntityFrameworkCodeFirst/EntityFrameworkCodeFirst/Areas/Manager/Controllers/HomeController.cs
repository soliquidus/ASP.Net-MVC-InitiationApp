using System.Web.Mvc;
using EntityFrameworkCodeFirst.Filters;

namespace EntityFrameworkCodeFirst.Areas.Manager.Controllers
{
    [ManagerAuthorization]
    public class HomeController : Controller
    {
        // GET
        public ActionResult Index()
        {
            return View();
        }
    }
}