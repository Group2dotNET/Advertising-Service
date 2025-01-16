using Contracts;
using AdvertisingService.Customers.Entities;

namespace AdvertisingService.Customers.Services.Abstract
{
    public interface IPersonalService
    {
        public Task<Customer> SaveUpdateInfo(UserInfoDto userInfo, Customer user);
    }
}
