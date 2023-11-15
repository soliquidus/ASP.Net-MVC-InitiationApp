using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EntityFrameworkCodeFirst.Identity;

namespace EntityFrameworkCodeFirst.Areas.Admin.Controllers
{
    public class UsersController : Controller
    {
        // GET: Admin/Users/Index
        public ActionResult Index()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            List<ApplicationUser> existingUsers = db.Users.ToList();
            return View(existingUsers);
        }
    }
}