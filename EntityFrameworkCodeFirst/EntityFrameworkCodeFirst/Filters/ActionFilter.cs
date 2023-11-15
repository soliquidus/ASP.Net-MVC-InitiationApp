using System.Web.Mvc;

namespace EntityFrameworkCodeFirst.Filters
{
    public class ActionFilter : FilterAttribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.Controller.ViewBag.NoOfVisitorsOfTheDay = 50;
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.Controller.ViewBag.NoOfVisitorsOfTheDay = 70;
        }
    }
}