using Microsoft.AspNet.Identity;

namespace EntityFrameworkCodeFirst.Identity
{
    public class ApplicationUserManager: UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store) : base(store)
        {
        }
    }
}