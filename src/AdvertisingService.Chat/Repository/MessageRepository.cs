using AdvertisingService.Chat.Contracts;
using AdvertisingService.Chat.Entities;
using AdvertisingService.Chat.Interfaces;
using AutoMapper;
using Contracts;

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

        public async Task<Message> Send(CreateMsgDto message)
        {
            var msg = _mapper.Map<Message>(message);
            msg.DateSent = DateTime.UtcNow;
            await _context.Messages.AddAsync(msg);
            await _context.SaveChangesAsync();
            return msg;
        }

        public async Task Delete(long messageId, string UserName)
        {
            var msg = await _context.Messages.FindAsync(messageId);
            if (msg != null)
            {
                if (msg.Chat.Sender == UserName)
                {
                    msg.SenderDeleted = true;
                }
                else if (msg.Chat.Receiver == UserName)
                {
                    msg.ReceiverDeleted = true;
                }
                _context.Entry(msg).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }
    }
}
