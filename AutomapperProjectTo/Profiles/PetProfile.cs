using AutoMapper;
using AutomapperProjectTo.Models;
using AutomapperProjectTo.Models.Responses;

namespace AutomapperProjectTo.Profiles
{
    public class PetProfile : Profile
    {
        public PetProfile()
        {
            CreateMap<Pet, PetResponse>();
        }
    }
}
