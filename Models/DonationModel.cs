using System.ComponentModel.DataAnnotations;

namespace WoofHub_App.Models
{
    public class DonationModel
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(155, ErrorMessage = "O nome deve ter no máximo 155 caracteres")]
        public string? DonorsName { get; set; }

        [Required]
        public float? Value { get; set; }

        [Required]
        [MaxLength(5000, ErrorMessage = "A descrição deve ter no máximo 5000 caractereres")]
        public string? Description { get; set; }
    }
}
