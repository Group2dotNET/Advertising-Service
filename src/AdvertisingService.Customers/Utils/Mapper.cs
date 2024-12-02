using AdvertisingService.Customers.DTO;
using AdvertisingService.Customers.Entities;

namespace AdvertisingService.Customers.Utils
{
    public class Mapper
    {
        public static Customer Map(UserRegisterDto dto)
        {
            return new Customer
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                MiddleName = dto.MiddleName ?? "",
                Email = dto.Email,
                UserName = dto.Email
            };
        }
    }
}
