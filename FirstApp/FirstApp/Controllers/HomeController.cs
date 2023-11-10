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
            else
            {
                return Redirect(fbUrl);
            }
        }
    }
}