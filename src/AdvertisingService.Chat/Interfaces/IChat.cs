﻿using AdvertisingService.Chat.Contracts;
using AdvertisingService.Chat.Helpers;
using Contracts;

namespace AdvertisingService.Chat.Interfaces
{
    public interface IChat
    {
        public Task Create(ChatDto chatDto);
        public Task Delete(long Id);
        public Task<IEnumerable<MessageDto>> GetMessagesForUser(string Id);
        public Task<IEnumerable<MessageDto>> GetMessageThread(ChatDto chatDto);
    }
}
