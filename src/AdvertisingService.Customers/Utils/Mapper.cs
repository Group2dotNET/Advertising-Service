using AdvertisingService.Customers.Contracts;
using AdvertisingService.Customers.Entities;
using Contracts;

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
        public static Customer MapInfo(UserInfoDto dto, Customer user)
        {
            user.LastName = dto.LastName;
            user.FirstName = dto.FirstName;
            user.MiddleName = dto.MiddleName;
            user.Birthday = dto.Birthday;
            user.PhoneNumber = dto.PhoneNumber;
            user.Address = dto.Address;
            user.Bio = dto.Bio;
            return user;
        }
    }
}
