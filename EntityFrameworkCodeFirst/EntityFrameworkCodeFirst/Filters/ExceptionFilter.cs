using System.IO;
using System.Web.Mvc;

namespace EntityFrameworkCodeFirst.Filters
{
    public class ExceptionFilter: FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            string s = "Message: " + filterContext.Exception.Message + ", Type: " + filterContext.Exception.GetType().ToString() + ", Source: " + filterContext.Exception.Source;
            StreamWriter sw = File.AppendText(filterContext.RequestContext.HttpContext.Request.PhysicalApplicationPath + "\\ErrorLog.txt");
            sw.WriteLine(s);
            sw.Close();
            filterContext.ExceptionHandled = true;
            filterContext.Result = new RedirectResult("~/Error.html");
        }
    }
}