namespace AutomapperProjectTo.Models.Responses
{
    public class HumanResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public List<PetResponse> Pets { get; set; } = new List<PetResponse>();
    }
}
