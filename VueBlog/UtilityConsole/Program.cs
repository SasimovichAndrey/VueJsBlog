using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using VueBlog.Database;

namespace UtilityConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var ctx = new BlogDbContext();
            var userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(ctx));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(ctx));

            var adminRole = new IdentityRole("Admin");
            roleManager.Create(adminRole);

            var adminPassword = "";
            var adminUser = new IdentityUser("Administrator");
            var user = userManager.Create(adminUser, adminPassword);

            userManager.AddToRoles(adminUser.Id, "Admin");
        }
    }
}
