using AdvertisingService.Customers.Contracts;
using AdvertisingService.Customers.Entities;

namespace AdvertisingService.Customers.Services.Abstract
{
    public interface IAdminService
    {
        public Task AddRoleAsync(string role);
        public Task SetRoleAsync(Customer user, string role);
    }
}
