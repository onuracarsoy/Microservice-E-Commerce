using AutoMapper;
using Shop.Message.Dal.Entities;
using Shop.Message.Dtos;

namespace Shop.Message.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<UserMessage,ResultMessageDto>().ReverseMap();
            CreateMap<UserMessage,InboxMessageDto>().ReverseMap();
            CreateMap<UserMessage,SendboxMessageDto>().ReverseMap();
            CreateMap<UserMessage,CreateMessageDto>().ReverseMap();
            CreateMap<UserMessage,UpdateMessageDto>().ReverseMap();
        }
    }
}
