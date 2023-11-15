using System.Web.Mvc;

namespace EntityFrameworkCodeFirst.Filters
{
    public class ManagerAuthorization : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.User.IsInRole("Manager") == false)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }
    }
}



