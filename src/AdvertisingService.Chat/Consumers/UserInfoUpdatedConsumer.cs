using AdvertisingService.Chat.Interfaces;
using Contracts;
using MassTransit;

namespace AdvertisingService.Chat.Consumers
{
    public class UserInfoUpdatedConsumer : IConsumer<UserInfoDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserInfoUpdatedConsumer(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Consume(ConsumeContext<UserInfoDto> context)
        {
            UserInfoDto userInfo = context.Message;
            try
            {
                await _unitOfWork.UserRepository.Update(userInfo);
                await _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                return;
            }
        }
    }
}
