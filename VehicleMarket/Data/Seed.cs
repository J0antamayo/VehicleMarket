using Microsoft.AspNetCore.Identity;
using VehicleMarket.Helpers;
using VehicleMarket.Models;

namespace VehicleMarket.Data
{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                //Makes
                if (!context.Makes.Any())
                {
                    context.Makes.AddRange(new List<Make>()
                    {
                        new Make()
                        {
                            Name = "Mitsubishi"
                        },
                        new Make()
                        {
                            Name = "Harley Davidson"
                        }
                    });
                    context.SaveChanges();
                }

                //Models
                if (!context.Models.Any())
                {
                    context.Models.AddRange(new List<Model>()
                    {
                        new Model()
                        {
                            Name = "2000",
                            MakeId = 1,
                        },
                        new Model()
                        {
                            Name = "CB120F",
                            Make = new Make()
                            {
                                Name = "Honda"
                            }
                        }
                    });
                    context.SaveChanges();
                }
            }
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                //Create Admin Role if not exists
                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

                //Create Executive Role if not exists
                if (!await roleManager.RoleExistsAsync(UserRoles.Executive))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Executive));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                //Create Admin User
                string adminUserEmail = "joansebtamayodev@gmail.com";
                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);

                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        UserName = adminUserEmail,
                        Email = adminUserEmail,
                        EmailConfirmed = true,
                        FirstName = "Joan",
                        LastName = "Tamayo"
                    };
                    await userManager.CreateAsync(newAdminUser, "Password123#");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

                //Create Executive User
                string executiveUserEmail = "executive@vehiclemarket.com";
                var executiveUser = await userManager.FindByEmailAsync(executiveUserEmail);

                if (executiveUser == null)
                {
                    var newExecutiveUser = new ApplicationUser()
                    {
                        UserName = executiveUserEmail,
                        Email = executiveUserEmail,
                        EmailConfirmed = true,
                        FirstName = "Executive",
                        LastName = "Executive"
                    };
                    await userManager.CreateAsync(newExecutiveUser, "Password123#");
                    await userManager.AddToRoleAsync(newExecutiveUser, UserRoles.Executive);
                }
            }
        }
    }
}
