using AdvertisingService.Customers.Contracts;
using AdvertisingService.Customers.Entities;
using AutoMapper;
using Contracts;

namespace AdvertisingService.Customers.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<UserInfoDto, Customer>().ReverseMap();
            CreateMap<UserRegisterDto, Customer>()
                .ForMember(c => c.UserName, opt => opt.MapFrom(dto => dto.Email));
            CreateMap<Customer, UserRegisterInfoDto>();

        }
    }
}
