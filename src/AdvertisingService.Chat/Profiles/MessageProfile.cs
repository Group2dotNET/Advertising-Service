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
            CreateMap<Entities.Chat, ChatDto>();
            CreateMap<ChatDto, Entities.Chat>();
            CreateMap<Message, MessageDto>()
                .ForPath(dest => dest.Sender, opt => opt.MapFrom(src =>
                    src.Chat.Sender))
                .ForPath(dest => dest.Receiver, opt => opt.MapFrom(src =>
                    src.Chat.Receiver));
            CreateMap<MessageDto, Message>();
            CreateMap<Message, CreateMsgDto>();
            CreateMap<CreateMsgDto, Message>();
        }
    }
}
