using WoofHub_App.Data.Dtos.AdoptionDto;

namespace WoofHub_App.Data.Dtos.AnimalDtos
{
    public class ReadAnimalDto
    {
        public int Id { get; set; }
        public string? AnimalName { get; set; }
        public string? Animal { get; set; }
        public string? Age { get; set; }
        public string? Description { get; set; }
        public string? Situation { get; set; }
        public string? Size { get; set; }
        public string? Vaccine { get; set; }
        public string? Treatment { get; set; }
        public DateTime ConsultationTime { get; set; } = DateTime.Now;
        public ICollection<ReadAdoptionDto>? Adoption { get; set; }
    }
}