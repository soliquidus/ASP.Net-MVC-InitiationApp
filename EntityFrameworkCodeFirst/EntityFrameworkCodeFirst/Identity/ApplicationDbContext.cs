using Microsoft.AspNet.Identity.EntityFramework;

namespace EntityFrameworkCodeFirst.Identity
{
    public class ApplicationDbContext: IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base("defaultConnection")
        {
        }
    }
}