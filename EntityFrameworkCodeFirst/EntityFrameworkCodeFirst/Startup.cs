using EntityFrameworkCodeFirst;
using EntityFrameworkCodeFirst.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace EntityFrameworkCodeFirst
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions() {AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie, LoginPath = new PathString("/Account/Login")});
            this.CreateRolesAndUsers();
        }

        private void CreateRolesAndUsers()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>());
            var appDbContext = new ApplicationDbContext();
            var appUserStore = new ApplicationUserStore(appDbContext);
            var userManager = new ApplicationUserManager(appUserStore);

            // Create Admin Role
            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole {Name = "Admin"};
                roleManager.Create(role);
            }
            
            // Create Admin User
            if (userManager.FindByName("admin") == null)
            {
                var user = new ApplicationUser {UserName = "admin", Email = "admin@testdomaine.com"};
                const string userPassword = "admin";
                var adminUser = userManager.Create(user, userPassword);

                if (adminUser.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Admin");
                }
            }
            
            //Create Manager Role
            if (!roleManager.RoleExists("Manager"))
            {
                var role = new IdentityRole {Name = "Manager"};
                roleManager.Create(role);
            }
            
            //Create Manager User
            if (userManager.FindByName("manager") == null)
            {
                var user = new ApplicationUser {UserName = "manager", Email = "manager@testdomaine.com"};
                const string userPassword = "manager";
                var managerUser = userManager.Create(user, userPassword);
                
                if (managerUser.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Manager");
                }
            }

            //Create Customer Role
            if (!roleManager.RoleExists("Customer"))
            {
                var role = new IdentityRole {Name = "Customer"};
                roleManager.Create(role);
            }
        }
    }
}