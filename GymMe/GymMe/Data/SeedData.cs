using GymMe.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GymMe.Data
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();

            string[] roleNames = { "Admin", "Customer" };
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            var adminUser = new User
            {
                UserName = "admin",
                Email = "admin@gymme.com"
            };

            var userPassword = "Admin@123";
            var admin = await userManager.FindByEmailAsync("admin@gymme.com");

            if (admin == null)
            {
                var createAdmin = await userManager.CreateAsync(adminUser, userPassword);
                if (createAdmin.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }

            var customerUser = new User
            {
                UserName = "customer",
                Email = "customer@gymme.com"
            };

            var customerPassword = "Customer@123";
            var customer = await userManager.FindByEmailAsync("customer@gymme.com");

            if (customer == null)
            {
                var createCustomer = await userManager.CreateAsync(customerUser, customerPassword);
                if (createCustomer.Succeeded)
                {
                    await userManager.AddToRoleAsync(customerUser, "Customer");
                }
            }
        }
    }
}
