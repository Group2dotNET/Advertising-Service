using AdvertisingService.Customers.DTO;

namespace AdvertisingService.Customers.Services
{
    public interface IJwtTokenService
    {
        Task<string> GenerateToken(string username, IList<string> roles);
    }
}
