using System.ComponentModel.DataAnnotations;

namespace AutomapperProjectTo.Models
{
    public class Pet
    {
        [Key]
        public Guid Id { get; set; }

        public string PetType { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public virtual Human Human { get; set; }
    }
}
