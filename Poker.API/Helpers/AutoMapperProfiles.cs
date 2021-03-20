using AutoMapper;
using Poker.API.DTOs;
using Poker.Domain;
using Poker.Domain.Identity;

namespace Poker.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User,UserDTO>().ReverseMap();
            CreateMap<User,UserLoginDTO>().ReverseMap();
            CreateMap<Carta,CartaDTO>().ReverseMap();
            CreateMap<Carta,CartaPostDTO>().ReverseMap();
            CreateMap<Historia, HistoriaDTO>().ReverseMap();
            CreateMap<Historia, HistoriaPostDTO>().ReverseMap();
        }
    }
}