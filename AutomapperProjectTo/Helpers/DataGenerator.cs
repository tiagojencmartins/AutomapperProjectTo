using AutomapperProjectTo.Enums;
using AutomapperProjectTo.Models;

namespace AutomapperProjectTo.Helpers
{
    public static class DataGenerator
    {
        public static IEnumerable<Human> GenerateHumansAndPets()
        {
            return
                Enumerable.Range(0, 50)
                .Select(_ => new Human
                {
                    Name = Guid.NewGuid().ToString(),
                    Prop1 = Guid.NewGuid().ToString(),
                    Prop2 = Guid.NewGuid().ToString(),
                    Prop3 = Guid.NewGuid().ToString(),
                    Pets = GeneratePets()
                });
        }

        private static List<Pet> GeneratePets()
        {
            var availablePets = new string[] { PetType.Cat, PetType.Dog };

            return
                Enumerable.Range(0, new Random().Next(5))
                .Select(_ => new Pet
                {
                    PetType = availablePets[new Random().Next(0, 2)]
                }).ToList();
        }
    }
}