using AutoMapper;
using ImplicitOperator.Models;
using ImplicitOperator.Models.Responses;

namespace ImplicitOperator.Profiles
{
    public class HumanProfile : Profile
    {
        public HumanProfile()
        {
            CreateMap<Human, HumanResponse>();
        }
    }
}
