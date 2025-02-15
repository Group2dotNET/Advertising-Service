using AdvertisingService.Chat.Entities;
using AdvertisingService.Chat.Interfaces;
using AutoMapper;
using Contracts;
using MassTransit;
using RabbitMQ.Client;

namespace AdvertisingService.Chat.Consumers
{
    public class UserRegisteredConsumer : IConsumer<UserRegisterInfoDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserRegisteredConsumer(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Consume(ConsumeContext<UserRegisterInfoDto> context)
        {
            UserRegisterInfoDto userInfo = context.Message;
            try
            {
                await _unitOfWork.UserRepository.Create(userInfo);
                await _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                return;
            }
        }
    }
}
