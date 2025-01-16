using Contracts;
using AdvertisingService.Customers.Entities;
using AdvertisingService.Customers.Services.Abstract;
using AdvertisingService.Customers.Utils;
using MassTransit;
using MassTransit.Transports;
using Microsoft.AspNetCore.Identity;

namespace AdvertisingService.Customers.Services.Concrete
{
    public class PersonalService : IPersonalService
    {
        private readonly UserManager<Customer> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IPublishEndpoint _publishEndpoint;
        public PersonalService(UserManager<Customer> userManager, RoleManager<IdentityRole> roleManager, IPublishEndpoint publishEndpoint)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<Customer> SaveUpdateInfo(UserInfoDto userInfo, Customer user)
        {
            Customer userNew = Mapper.MapInfo(userInfo, user);
            var updateResult = await _userManager.UpdateAsync(userNew);
            if (updateResult.Succeeded)
                await _publishEndpoint.Publish(userInfo);
            return userNew;
        }
    }
}
