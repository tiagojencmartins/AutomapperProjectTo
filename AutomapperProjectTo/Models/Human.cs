using System.ComponentModel.DataAnnotations;

namespace AutomapperProjectTo.Models
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
    }
}
