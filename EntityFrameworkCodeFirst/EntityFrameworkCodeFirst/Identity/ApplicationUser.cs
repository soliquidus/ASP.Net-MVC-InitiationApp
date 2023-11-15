using System;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EntityFrameworkCodeFirst.Identity
{
    public class ApplicationUser: IdentityUser
    {
        public DateTime? Birthday { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}