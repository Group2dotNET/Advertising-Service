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
            CreateMap<Entities.Chat, ChatDto>(); ;
            CreateMap<ChatDto, Entities.Chat>();
            CreateMap<Message, MessageDto>()
                .ForPath(dest => dest.SenderId, opt => opt.MapFrom(src =>
                    src.Chat.SenderId))
                .ForPath(dest => dest.SenderUserName, opt => opt.MapFrom(src =>
                    src.Chat.Sender.UserName))
                .ForPath(dest => dest.SenderName, opt => opt.MapFrom(src =>
                    src.Chat.Sender.LastName + " " + src.Chat.Sender.FirstName))
                .ForPath(dest => dest.ReceiverId, opt => opt.MapFrom(src =>
                    src.Chat.ReceiverId))
                .ForPath(dest => dest.ReceiverUserName, opt => opt.MapFrom(src =>
                    src.Chat.Receiver.UserName))
                .ForPath(dest => dest.ReceiverName, opt => opt.MapFrom(src =>
                    src.Chat.Receiver.LastName + " " + src.Chat.Receiver.FirstName));
            CreateMap<MessageDto, Message>();
            CreateMap<Message, CreateMsgDto>().ReverseMap();
            CreateMap<UserInfoDto, User>();
            CreateMap<UserRegisterInfoDto, User>();
        }
    }
}
