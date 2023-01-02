using ImplicitOperator.Models.Responses;
using System.ComponentModel.DataAnnotations;

namespace ImplicitOperator.Models
{
    public class Pet
    {
        [Key]
        public Guid Id { get; set; }

        public string PetType { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public virtual Human Human { get; set; }

        public static implicit operator PetResponse(Pet entry)
        {
            return new PetResponse
            {
                Id = entry.Id,
                PetType = entry.PetType,
            };
        }
    }
}
