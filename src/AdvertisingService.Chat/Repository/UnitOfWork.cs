using AdvertisingService.Chat.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace AdvertisingService.Chat.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EFContext _context;
        private readonly IMapper _mapper;
        public UnitOfWork(EFContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IUser UserRepository => new UserRepository(_context, _mapper);
        public IChat ChatRepository => new ChatRepository(_context, _mapper);

        public IMessage MessageRepository => new MessageRepository(_context, _mapper);
        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
