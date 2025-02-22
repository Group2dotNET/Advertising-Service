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
        private readonly object _lock = new();
        public MessageRepository(EFContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Send(CreateMsgDto message)
        {
            var msg = _mapper.Map<Message>(message);
            var chat = await _context.Chats.FirstOrDefaultAsync(c => c.SenderId == message.SenderId && c.ReceiverId == message.ReceiverId);
            if (chat != null)
            {
                msg.ChatId = chat.Id;
                msg.DateSent = DateTime.UtcNow;
                await _context.Messages.AddAsync(msg);
            }
        }

        public async Task Delete(DeleteMsgDto messageDto)
        {
            var msg = await _context.Messages.Include(m => m.Chat)
                .Include(m => m.Chat.Sender)
                .Include(m => m.Chat.Receiver)
                .FirstOrDefaultAsync(m => m.Id == messageDto.MessageId);
            if (msg != null)
            {
                lock (_lock)
                {
                    if (msg.Chat.Sender.UserName == messageDto.UserName)
                    {
                        msg.SenderDeleted = true;
                    }
                    else if (msg.Chat.Receiver.UserName == messageDto.UserName)
                    {
                        msg.ReceiverDeleted = true;
                    }
                    _context.Entry(msg).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();
                }
            }
        }
    }
}
