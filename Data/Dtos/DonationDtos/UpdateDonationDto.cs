using System.ComponentModel.DataAnnotations;

namespace WoofHub_App.Data.Dtos.DonationDtos
{
    public class UpdateDonationDto
    {
        [Required]
        public float? Value { get; set; }

        [Required]
        [StringLength(155, ErrorMessage = "O nome do doador deve ter no máximo 155 caracteres")]
        public string? DonorsName { get; set; }
        
        [Required]
        [StringLength(5000, ErrorMessage = "A descrição deve ter no máximo 5000 caractereres")]
        public string? Description { get; set; }
    }
}