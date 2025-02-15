using AdvertisingService.Chat.Contracts;
using AdvertisingService.Chat.Entities;
using AdvertisingService.Chat.Interfaces;
using AutoMapper;
using Contracts;
using Microsoft.EntityFrameworkCore;

namespace AdvertisingService.Chat.Repository
{
    public class MessageRepository : IMessage
    {
        private readonly EFContext _context;
        private readonly IMapper _mapper;
        public MessageRepository(EFContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Send(CreateMsgDto message)
        {
            var msg = _mapper.Map<Message>(message);
            var chat = await _context.Chats.FirstOrDefaultAsync(c => c.Sender == message.Sender && c.Receiver == message.Receiver);
            if (chat != null)
            {
                msg.ChatId = chat.Id;
                msg.DateSent = DateTime.UtcNow;
                await _context.Messages.AddAsync(msg);
            }
        }

        public async Task Delete(DeleteMsgDto messageDto)
        {
            var msg = await _context.Messages.Include(m => m.Chat).FirstOrDefaultAsync(m => m.Id == messageDto.MessageId);
            if (msg != null)
            {
                if (msg.Chat.Sender == messageDto.UserName)
                {
                    msg.SenderDeleted = true;
                }
                else if (msg.Chat.Receiver == messageDto.UserName)
                {
                    msg.ReceiverDeleted = true;
                }
                _context.Entry(msg).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
        }
    }
}
