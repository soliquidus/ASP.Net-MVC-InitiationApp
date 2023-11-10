using System.Web.Mvc;

namespace FirstApp.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login(string username, string password)
        {
            if (username == "admin" && password == "admin")
            {
                return RedirectToAction("Dashboard", "Admin");
            }

            return RedirectToAction("InvalidLogin");
        }
        
        public ActionResult InvalidLogin()
        {
            return View();
        }
    }
}