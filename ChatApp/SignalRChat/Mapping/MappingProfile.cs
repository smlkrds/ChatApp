using AutoMapper;
using SignalRChat.Dtos;
using SignalRChat.Entities;

namespace SignalRChat.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Message, MessageDto>(MemberList.Destination).ReverseMap();
        }
    }
}
