using System.ComponentModel.DataAnnotations;

namespace WoofHub_App.Data.Dtos.AnimalDtos
{
    public class UpdateAnimalDto
    {
        [Required]
        [StringLength(100)]
        public string? AnimalName { get; set; }

        [Required]
        [StringLength(155, ErrorMessage = "O nome deve conter no máximo 155 caracteres")]
        public string? Animal { get; set; }

        [Required]
        [StringLength(100)]
        public string? Age { get; set; }

        [StringLength(5000, ErrorMessage = "A descrição deve ter no máximo 5000 caractereres")]
        public string? Description { get; set; }

        [Required]
        [StringLength(100)]
        public string? Situation { get; set; }

        [Required]
        [StringLength(100)]
        public string? Size { get; set; }

        [Required]
        [StringLength(100)]
        public string? Vaccine { get; set; }

        [Required]
        [StringLength(100)]
        public string? Treatment { get; set; }
    }
}