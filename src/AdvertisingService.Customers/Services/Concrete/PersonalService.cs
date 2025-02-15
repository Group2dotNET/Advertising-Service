using Contracts;
using AdvertisingService.Customers.Entities;
using AdvertisingService.Customers.Services.Abstract;
using MassTransit;
using MassTransit.Transports;
using Microsoft.AspNetCore.Identity;
using AutoMapper;

namespace AdvertisingService.Customers.Services.Concrete
{
    public class PersonalService : IPersonalService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<Customer> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IBusControl _busControl;
        public PersonalService(IMapper mapper, UserManager<Customer> userManager, RoleManager<IdentityRole> roleManager, IBusControl busControl)
        {
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
            _busControl = busControl;
        }

        public async Task<Customer> SaveUpdateInfo(UserInfoDto userInfo, Customer user)
        {
            user.LastName = userInfo.LastName;
            user.FirstName = userInfo.FirstName;
            user.MiddleName = userInfo.MiddleName;
            user.PhoneNumber = userInfo.PhoneNumber;
            user.Birthday = userInfo.Birthday;
            user.Address = userInfo.Address;
            user.Bio = userInfo.Bio;

            var updateResult = await _userManager.UpdateAsync(user);
            if (updateResult.Succeeded)
                await _busControl.Publish(userInfo);
            return user;
        }
    }
}
