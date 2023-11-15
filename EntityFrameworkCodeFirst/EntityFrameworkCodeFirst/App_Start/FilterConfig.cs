using System.Web.Mvc;
using EntityFrameworkCodeFirst.Filters;

namespace EntityFrameworkCodeFirst
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new ExceptionFilter());
        }
    }
}