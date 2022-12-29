using AutoMapper;
using AutomapperProjectTo.Models;
using AutomapperProjectTo.Models.Responses;

namespace AutomapperProjectTo.Profiles
{
    public class HumanProfile : Profile
    {
        public HumanProfile()
        {
            CreateMap<Human, HumanResponse>();
        }
    }
}
