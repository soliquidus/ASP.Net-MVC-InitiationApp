using System.Collections.Generic;
using System.Web.Mvc;

namespace FirstApp.Controllers
{
    public class HomeController : Controller
    {
        // GET
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Products()
        {
            return View("OurCompanyProducts");
        }

        public ActionResult Contact()
        {
            ViewBag.TollFree = "123-123-123";
            return View();
        }

        // ContentResult Type
        public ActionResult GetEmpName(int empId)
        {
            var employees = new[]
            {
                new {empId = 1, empName = "Scott", salary = 8000},
                new {empId = 2, empName = "Smith", salary = 2450},
                new {empId = 1, empName = "Allen", salary = 9400}
            };

            string matchEmpName = "null";

            foreach (var employee in employees)
            {
                if (employee.empId == empId)
                {
                    matchEmpName = employee.empName;
                }
            }

            // return new ContentResult() {Content = matchEmpName, ContentType = "text/plain"};
            return Content(matchEmpName, "text/plain");
        }

        // FileResult Type
        public ActionResult GetPaySlip(int empId)
        {
            string fileName = "~/PaySlip" + empId + ".pdf";
            return File(fileName, "application/pdf");
        }

        // RedirectResult Type
        public ActionResult EmpFacebookPage(int empId)
        {
            var employees = new[]
            {
                new {empId = 1, empName = "Scott", salary = 8000},
                new {empId = 2, empName = "Smith", salary = 2450},
                new {empId = 1, empName = "Allen", salary = 9400}
            };
            string fbUrl = null;

            foreach (var employee in employees)
            {
                if (employee.empId == empId)
                {
                    fbUrl = "http://facebook.com/emp" + empId;
                }
            }

            if (fbUrl == null)
            {
                return Content("Invalid emp id");
            }

            return Redirect(fbUrl);
        }

        public ActionResult StudentDetails()
        {
            ViewBag.StudentId = 101;
            ViewBag.StudentName = "Scott";
            ViewBag.Marks = 80;
            ViewBag.NoOfSemesters = 6;
            ViewBag.Subjects = new List<string>() { "Maths", "Physics", "Chemistry" };
            return View();
        }
        
        public ActionResult RequestExample()
        {
            ViewBag.Url = Request.Url;
            ViewBag.PhysicalApplicationPath = Request.PhysicalApplicationPath;
            ViewBag.Path = Request.Path;
            ViewBag.BrowserType = Request.Browser.Type;
            ViewBag.QueryString = Request.QueryString["n"];
            ViewBag.Headers = Request.Headers["Accept"];
            ViewBag.HttpMethod = Request.HttpMethod;
            return View();
        }
        
        public ActionResult ResponseExample()
        {
            Response.Write("Hello from ResponseExample");
            Response.ContentType = "text/html";
            Response.Headers["Server"] = "My Server";
            Response.StatusCode = 500;
            return View();
        }
    }
}