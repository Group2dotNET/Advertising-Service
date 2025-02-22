using AdvertisingService.Chat.Contracts;
using AdvertisingService.Chat.Helpers;
using AdvertisingService.Chat.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Contracts;
using Microsoft.EntityFrameworkCore;

namespace AdvertisingService.Chat.Repository
{
    public class ChatRepository : IChat
    {
        private readonly EFContext _context;
        private readonly IMapper _mapper;
        public ChatRepository(EFContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task Create(ChatDto chatDto)
        {
            bool chatExists = await _context.Chats.AnyAsync(x => x.SenderId == chatDto.SenderId && x.ReceiverId == chatDto.ReceiverId);
            if (!chatExists)
            {
                var chat = _mapper.Map<Entities.Chat>(chatDto);
                chat.DateCreated = DateTime.UtcNow;
                await _context.Chats.AddAsync(chat);
            }
        }

        public async Task Delete(long Id)
        {
            var chat = await _context.Chats.FindAsync(Id);
            if (chat != null)
            {
                _context.Chats.Remove(chat);
            }
        }

        public async Task<IEnumerable<MessageDto>> GetMessagesForUser(string Id)
        {
            var messages = await _context.Messages.Include(m => m.Chat).Include(m => m.Chat.Sender).Include(m => m.Chat.Receiver)
                .Where(u => u.Chat.ReceiverId == Id && u.DateRead == null && u.ReceiverDeleted == false)
                .OrderByDescending(m => m.DateSent)
                .ToListAsync();

            return messages.Select(m => _mapper.Map<MessageDto>(m));
        }

        public async Task<IEnumerable<MessageDto>> GetMessageThread(ChatDto chatDto)
        {
            var messages = await _context.Messages.Include(m => m.Chat).Include(m => m.Chat.Sender).Include(m => m.Chat.Receiver)
                .Where(m => m.Chat.ReceiverId == chatDto.SenderId && m.ReceiverDeleted == false
                        && m.Chat.SenderId == chatDto.ReceiverId
                        || m.Chat.ReceiverId == chatDto.ReceiverId
                        && m.Chat.SenderId == chatDto.SenderId && m.SenderDeleted == false)
                .OrderBy(m => m.DateSent).ToListAsync();
            foreach (var message in messages.Where(m => m.DateRead == null && m.Chat.ReceiverId == chatDto.SenderId))
            {
                message.DateRead = DateTime.UtcNow;
                _context.Entry(message).State = EntityState.Modified;
            }
            await _context.SaveChangesAsync();

            return messages.Select(m => _mapper.Map<MessageDto>(m));
        }
    }
}
