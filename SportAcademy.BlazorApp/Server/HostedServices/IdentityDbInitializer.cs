using Microsoft.AspNetCore.Identity;

namespace SportAcademy.BlazorApp.Server.HostedServices
{
    public class IdentityDbInitializer
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        public IdentityDbInitializer(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }   
        public async Task SeedAsync()
        {
            string[] roles = { "Admin", "Staff", "Players" };
            foreach (string role in roles)
            {
                await this.CreateRole(role);
            }
            var user1 = new IdentityUser { UserName = "Admin" };
            await CreateUser(user1, "@ESADCSR54", "Admin");
            var user2 = new IdentityUser { UserName = "Staff" };
            await CreateUser(user2, "@ESADCSR54", "Staff");
            var user3 = new IdentityUser { UserName = "Players" };
            await CreateUser(user3, "@ESADCSR54", "Players");
        }
        private async Task CreateRole(string roleName)
        {
            var exists = await roleManager.RoleExistsAsync(roleName);
            if(!exists)
            {
               await  roleManager.CreateAsync(new IdentityRole {  Name = roleName, NormalizedName=roleName.ToUpper() });
            }
            
        }
        private async Task CreateUser(IdentityUser user, string password, string role)
        {
            var u = await userManager.FindByNameAsync(user.UserName ?? "");
            if(u == null)
            {
                await userManager.CreateAsync(user, password);
                await userManager.AddToRoleAsync(user, role);
            }
        }
    }
}
