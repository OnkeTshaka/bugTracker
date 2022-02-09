using bugTracker.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(bugTracker.Startup))]
namespace bugTracker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
        }
        // In this method we will create default User roles and Admin user for login
        private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


            // In Startup iam creating first Admin Role and creating a default Admin User 
            if (!roleManager.RoleExists("Admin"))
            {

                // first we create Admin role
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                //Here we create a Admin super user who will maintain the website				

                var user = new ApplicationUser();
                user.UserName = "Firewall";
                user.Email = "firewalls@gmail.com";
                string userPWD = "Fire101Walls#@";

                var chkUser = UserManager.Create(user, userPWD);

                //Add default User to Role Admin
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");

                }
            }

            // creating Creating Developer role 
            if (!roleManager.RoleExists("Developer"))
            {
                // first we create Admin role
                var role = new IdentityRole();
                role.Name = "Developer";
                roleManager.Create(role);

                //Here we create a Admin super user who will maintain the website				

                var user = new ApplicationUser();
                user.UserName = "Developer";
                user.Email = "dev@gmail.com";
                string userPWD = "dev101zar#@";

                var chkUser = UserManager.Create(user, userPWD);

                //Add default User to Role Admin
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Developer");

                }
            }
            // creating Creating Project Manager role 
            if (!roleManager.RoleExists("Project Manager"))
            {
                // first we create Project Manager role
                var role = new IdentityRole();
                role.Name = "Project Manager";
                roleManager.Create(role);

                //Here we create a Admin super user who will maintain the website				

                var user = new ApplicationUser();
                user.UserName = "Project";
                user.Email = "pro@gmail.com";
                string userPWD = "pro101manager#@";

                var chkUser = UserManager.Create(user, userPWD);

                //Add default User to Role Admin
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Project Manager");

                }
            }
            // creating Creating Contributor role 
            if (!roleManager.RoleExists("Contributor"))
            {
                // first we create Contributor role
                var role = new IdentityRole();
                role.Name = "Contributor";
                roleManager.Create(role);

                //Here we create a Contributor super user who will maintain the website				

                var user = new ApplicationUser();
                user.UserName = "Contributor";
                user.Email = "contributor@gmail.com";
                string userPWD = "contri101butors#@";

                var chkUser = UserManager.Create(user, userPWD);

                //Add default User to Role Admin
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Contributor");

                }
            }
        }
    }
}
