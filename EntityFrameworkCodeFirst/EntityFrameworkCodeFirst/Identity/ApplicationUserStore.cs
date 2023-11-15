using Microsoft.AspNet.Identity.EntityFramework;

namespace EntityFrameworkCodeFirst.Identity
{
    public class ApplicationUserStore: UserStore<ApplicationUser>
    {
        public ApplicationUserStore(ApplicationDbContext dbContext): base(dbContext)
        {
        }
    }
}