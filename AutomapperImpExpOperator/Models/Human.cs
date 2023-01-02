using ImplicitOperator.Models.Responses;
using System.ComponentModel.DataAnnotations;

namespace ImplicitOperator.Models
{
    public class Human
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Prop1 { get; set; }

        public string Prop2 { get; set; }

        public string Prop3 { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public virtual ICollection<Pet> Pets { get; set; } = new HashSet<Pet>();

        public static implicit operator HumanResponse(Human entry)
        {
            return new HumanResponse
            {
                Id = entry.Id,
                Name = entry.Name,
                Pets = entry.Pets.Select(pet => (PetResponse)pet).ToList()
            };
        }
    }
}
