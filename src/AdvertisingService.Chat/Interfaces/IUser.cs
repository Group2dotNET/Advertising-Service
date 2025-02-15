using AdvertisingService.Chat.Entities;
using Contracts;

namespace AdvertisingService.Chat.Interfaces
{
    public interface IUser
    {
        public Task Create(UserRegisterInfoDto userInfoDto);
        public Task Update(UserInfoDto userInfoDto);
    }
}
