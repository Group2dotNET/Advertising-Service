using AdvertisingService.Chat.Contracts;
using AdvertisingService.Chat.Entities;
using Contracts;

namespace AdvertisingService.Chat.Interfaces
{
    public interface IMessage
    {
        public Task Send(CreateMsgDto message);
        public Task Delete(DeleteMsgDto message);
    }
}
