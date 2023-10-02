using System.ComponentModel.DataAnnotations;

namespace WoofHub_App.Models
{
    public class AdoptionModel
    {
        [Key]
        public int Id { get; set; }
        public required ClientModel Client { get; set; }
        public required AnimalModel Animal { get; set; }
        public string? Situation { get; set; }
        public DateOnly Date { get; set; }
    }
}