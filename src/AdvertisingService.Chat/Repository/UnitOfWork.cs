using AdvertisingService.Chat.Interfaces;
using AutoMapper;

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

        public IChat ChatRepository => new ChatRepository(_context, _mapper);

        public IMessage MessageRepository => new MessageRepository(_context, _mapper);
    }
}
