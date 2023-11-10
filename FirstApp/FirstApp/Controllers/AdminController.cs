using System.Web.Mvc;

namespace FirstApp.Controllers
{
    public class AdminController : Controller
    {
        // GET
        public ActionResult Dashboard()
        {
            return View();
        }
    }
}