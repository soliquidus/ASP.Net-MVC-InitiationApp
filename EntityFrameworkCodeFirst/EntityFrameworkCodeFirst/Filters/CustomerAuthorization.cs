using System.Web.Mvc;

namespace EntityFrameworkCodeFirst.Filters
{
    public class CustomerAuthorization: FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.User.IsInRole("Customer") == false)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }
    }
}