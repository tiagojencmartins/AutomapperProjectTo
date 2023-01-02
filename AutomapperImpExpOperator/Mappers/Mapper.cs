using ImplicitOperator.Models;
using ImplicitOperator.Models.Responses;

namespace ImplicitOperator.Mappers
{
    public static class Mapper
    {
        public static PetResponse ToPetResponse(this Pet entry)
        {
            return new PetResponse
            {
                Id = entry.Id,
                PetType = entry.PetType,
            };
        }

        public static HumanResponse ToHumanResponse(this Human entry)
        {
            return new HumanResponse
            {
                Id = entry.Id,
                Name = entry.Name,
                Pets = entry.Pets.Select(pet => pet.ToPetResponse()).ToList()
            };
        }
    }
}
