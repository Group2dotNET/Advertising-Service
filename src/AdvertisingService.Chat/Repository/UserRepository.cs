using AdvertisingService.Chat.Contracts;
using AdvertisingService.Chat.Entities;
using AdvertisingService.Chat.Interfaces;
using AutoMapper;
using Contracts;

namespace AdvertisingService.Chat.Repository
{
    public class UserRepository : IUser
    {
        private readonly EFContext _context;
        private readonly IMapper _mapper;
        public UserRepository(EFContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Create(UserRegisterInfoDto userInfoDto)
        {
            var user = _mapper.Map<User>(userInfoDto);
            await _context.Users.AddAsync(user);
        }

        public async Task Update(UserInfoDto userInfoDto)
        {
            var user = await _context.Users.FindAsync(userInfoDto.Id);
            if (user != null)
            {
                user.FirstName = userInfoDto.FirstName;
                user.LastName = userInfoDto.LastName;
                _context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
        }
    }
}
