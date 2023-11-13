using System.Web.Mvc;
using ModelInitiation.Models;

namespace ModelInitiation.Controllers
{
    public class StudentsController : Controller
    {
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([ModelBinder(typeof (CustomBinder) )] Student stu )
        {
            return View();
        }
    }
}