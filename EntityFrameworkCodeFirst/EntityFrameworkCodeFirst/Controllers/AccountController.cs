using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using EntityFrameworkCodeFirst.Identity;
using EntityFrameworkCodeFirst.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

namespace EntityFrameworkCodeFirst.Controllers
{
    

    public class AccountController : Controller
    {
        private static readonly ApplicationDbContext AppDbContext = new ApplicationDbContext();
        private static readonly ApplicationUserStore UserStore = new ApplicationUserStore(AppDbContext);
        private static readonly ApplicationUserManager UserManager = new ApplicationUserManager(UserStore);
        
        // GET: Account/Register
        [ActionName("Register")]
        public ActionResult RegisterPage()
        {
            return View();
        }

        // POST: Account/Register
        [HttpPost]
        public ActionResult Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                // Registration
                var appDbContext = new ApplicationDbContext();
                var userStore = new ApplicationUserStore(appDbContext);
                var userManager = new ApplicationUserManager(userStore);
                var passwordHash = Crypto.HashPassword(registerViewModel.Password);
                var user = new ApplicationUser()
                {
                    Email = registerViewModel.Email,
                    UserName = registerViewModel.Username,
                    PasswordHash = passwordHash,
                    City = registerViewModel.City,
                    Country = registerViewModel.Country,
                    Birthday = registerViewModel.DateOfBirth,
                    Address = registerViewModel.Address,
                    PhoneNumber = registerViewModel.Mobile
                };
                IdentityResult result = userManager.Create(user);
                
                if (result.Succeeded)
                {
                    // Role
                    userManager.AddToRole(user.Id, "Customer");

                    // Login
                    this.LoginUser(user);
                }
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("Registration error", "Invalid data");
            return View();
        }
        

        // GET: Account/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: Account/Login
        [HttpPost]
        [OverrideExceptionFilters]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            // Login
            var user = UserManager.Find(loginViewModel.Username, loginViewModel.Password);
            if (user != null)
            {
                // Login
                this.LoginUser(user);
                
                if (UserManager.IsInRole(user.Id, "Admin"))
                {
                    return RedirectToAction("Index", "Home", new { area = "Admin" } );
                }

                if (UserManager.IsInRole(user.Id, "Manager"))
                {
                    return RedirectToAction("Index", "Home", new { area = "Manager" } );
                }
                
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("Login error", "Invalid username or password");
            return View();
        }
        
        // GET: Account/Logout
        public ActionResult Logout()
        {
            var authenticationManager = HttpContext.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
        
        // GET: Account/MyProfile
        public ActionResult MyProfile()
        {
            ApplicationUser appUser = UserManager.FindById(User.Identity.GetUserId());
            return View(appUser);
        }
        
        [NonAction]
        private void LoginUser(ApplicationUser user)
        {
            var authenticationManager = HttpContext.GetOwinContext().Authentication;
            var userIdentity = UserManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
            authenticationManager.SignIn(new AuthenticationProperties(), userIdentity);
        }
    }
}