using AdvertisingService.Chat.Contracts;
using AdvertisingService.Chat.Entities;
using AutoMapper;
using Contracts;

namespace AdvertisingService.Chat.Profiles
{
    public class MessageProfile : Profile
    {
        public MessageProfile()
        {
            CreateMap<Message, MessageDto>()
                .ForMember(dest => dest.Sender, opt => opt.MapFrom(src =>
                    src.Chat.Sender))
                .ForMember(dest => dest.Receiver, opt => opt.MapFrom(src =>
                    src.Chat.Receiver));
            CreateMap<MessageDto, Message>();
            CreateMap<Message, CreateMsgDto>();
        }
    }
}
