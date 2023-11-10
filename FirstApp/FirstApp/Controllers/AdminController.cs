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
        
        public ActionResult Contact()
        {
            ViewBag.TollFree = "525-525-525";
            return View();
        }
    }
}