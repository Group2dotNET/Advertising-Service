using AdvertisingService.Customers.Contracts;
using AdvertisingService.Customers.Entities;
using AdvertisingService.Customers.Services.Abstract;
using Microsoft.AspNetCore.Identity;
using System.Data;

namespace AdvertisingService.Customers.Services.Concrete
{
    public class AdminService : IAdminService
    {
        private readonly UserManager<Customer> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AdminService(UserManager<Customer> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task AddRoleAsync(string role)
        {
            bool roleExists = await _roleManager.RoleExistsAsync(role);
            if (!roleExists)
            {
                await _roleManager.CreateAsync(new IdentityRole
                {
                    Id = role,
                    Name = role,
                    NormalizedName = role
                });
            }
        }

        public async Task SetRoleAsync(Customer user, string role)
        {
            var roles = await _userManager.GetRolesAsync(user);
            Task removeFromRoles = _userManager.RemoveFromRolesAsync(user, roles);
            await removeFromRoles;
            if (removeFromRoles.IsCompletedSuccessfully)
            {
                await _userManager.AddToRoleAsync(user, role);
            }
        }
    }
}
