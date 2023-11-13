using System.Web.Mvc;

namespace LayoutViewsInitiation.Controllers
{
    public class HomeController : Controller
    {
        [Route("Home/Index")]
        [Route("")]
        public ActionResult Index()
        {
            return View();
        }
        
        [Route("Home/About")]
        public ActionResult About()
        {
            return View();
        }
        
        [Route("Home/Contact")]
        public ActionResult Contact()
        {
            return View();
        }
        
        [Route("Profile")]
        public ActionResult UserProfile()
        {
            return View();
        }
    }
}