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
        public async Task<Entities.Chat> Create(ChatDto chatDto)
        {
            var chat = _mapper.Map<Entities.Chat>(chatDto);
            chat.DateCreated = DateTime.UtcNow;
            await _context.Chats.AddAsync(chat);
            await _context.SaveChangesAsync();
            return chat;
        }

        public async Task Delete(long Id)
        {
            var chat = await _context.Chats.FindAsync(Id);
            if (chat != null)
            {
                _context.Chats.Remove(chat);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<MessageDto>> GetMessagesForUser(string UserName)
        {
            var messages = await _context.Messages
                .Where(u => u.Chat.Receiver == UserName && u.DateRead == null && u.ReceiverDeleted == false)
                .OrderByDescending(m => m.DateSent)
                .ProjectTo<MessageDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return messages;
        }

        public async Task<IEnumerable<MessageDto>> GetMessageThread(ChatDto chatDto)
        {
            var messages = await _context.Messages.Include(m => m.Chat)
                .Where(m => m.Chat.Receiver == chatDto.Sender && m.ReceiverDeleted == false
                        && m.Chat.Sender == chatDto.Receiver
                        || m.Chat.Receiver == chatDto.Receiver
                        && m.Chat.Sender == chatDto.Sender && m.SenderDeleted == false)
                .OrderBy(m => m.DateSent).ToListAsync();
            foreach (var message in messages.Where(m => m.DateRead == null && m.Chat.Receiver == chatDto.Sender))
            {
                message.DateRead = DateTime.UtcNow;
                _context.Entry(message).State = EntityState.Modified;
            }
            await _context.SaveChangesAsync();

            return messages.Select(m => _mapper.Map<MessageDto>(m));
        }
    }
}
