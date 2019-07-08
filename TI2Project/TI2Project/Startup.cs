using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using TI2Project.Models;

[assembly: OwinStartupAttribute(typeof(TI2Project.Startup))]
namespace TI2Project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            addUsers();
        }

        /// <summary>
        /// criar os utilizadores no sistema
        /// </summary>
        private void addUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new
            RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new
            UserStore<ApplicationUser>(context));
            // criaçao da role admin e das contas dos administradores

            if (!roleManager.RoleExists("Admin"))
            {
                // criaçao da role admin
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();

                role.Name = "Admin";
                roleManager.Create(role);
                //criaçao do admin vasco
                var userVM = new ApplicationUser();
                userVM.UserName = "vasco@web.com";
                userVM.Email = "vasco@web.com";
                string userVMPWD = "aA123.";
                var chkUserVM = userManager.Create(userVM, userVMPWD);
                //Add default User to Role Admin
                if (chkUserVM.Succeeded)
                {
                    var result1 = userManager.AddToRole(userVM.Id, "Admin");
                }

                //criaçao do admin henrique
                var userH = new ApplicationUser();
                userH.UserName = "henrique@web.com";
                userH.Email = "henrique@web.com";
                string userHPWD = "aA123.";
                var chkUserH = userManager.Create(userH, userHPWD);
                //Add default User to Role Admin
                if (chkUserH.Succeeded)
                {
                    var result1 = userManager.AddToRole(userH.Id, "Admin");
                }
            }
        }
    }
}
