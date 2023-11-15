using System.Web.Mvc;

namespace EntityFrameworkCodeFirst.Filters
{
    public class ResultFilter: FilterAttribute, IResultFilter
    {
        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            filterContext.Controller.ViewBag.NoOfVisitorsOfTheDay = 90;
        }

        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
        }
    }
}