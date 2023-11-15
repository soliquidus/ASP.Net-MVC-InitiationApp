using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using EntityFrameworkCodeFirst.Identity;
using EntityFrameworkCodeFirst.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace EntityFrameworkCodeFirst.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account/Register
        public ActionResult Register()
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
                    var authenticationManager = HttpContext.GetOwinContext().Authentication;
                    var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    authenticationManager.SignIn(new AuthenticationProperties(), userIdentity);
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
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            // Login
            var appDbContext = new ApplicationDbContext();
            var userStore = new ApplicationUserStore(appDbContext);
            var userManager = new ApplicationUserManager(userStore);
            var user = userManager.Find(loginViewModel.Username, loginViewModel.Password);
            if (user != null)
            {
                // Login
                var authenticationManager = HttpContext.GetOwinContext().Authentication;
                var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                authenticationManager.SignIn(new AuthenticationProperties(), userIdentity);
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
    }
}