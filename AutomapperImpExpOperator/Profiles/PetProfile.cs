using AutoMapper;
using ImplicitOperator.Models;
using ImplicitOperator.Models.Responses;

namespace ImplicitOperator.Profiles
{
    public class PetProfile : Profile
    {
        public PetProfile()
        {
            CreateMap<Pet, PetResponse>();
        }
    }
}
