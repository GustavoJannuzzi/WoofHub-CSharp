using System.ComponentModel.DataAnnotations;

namespace WoofHub_App.Models
{
    public class AnimalModel
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string? AnimalName { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Animal { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Age { get; set; }
        
        [MaxLength(5000, ErrorMessage = "A descrição deve ter no máximo 5000 caractereres")]
        public string? Description { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Situation { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Size { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string? Vaccine { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Treatment { get; set; }
        public virtual ICollection<AdoptionModel>? Adoptions { get; set; }
        public virtual ICollection<ClientModel>? Clients { get; set; }
    }
}