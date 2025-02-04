using AdvertisingService.Chat.Contracts;
using AdvertisingService.Chat.Entities;
using Contracts;

namespace AdvertisingService.Chat.Interfaces
{
    public interface IMessage
    {
        public Task<Message> Send(CreateMsgDto message);
        public Task Delete(long messageId, string UserName);
    }
}
