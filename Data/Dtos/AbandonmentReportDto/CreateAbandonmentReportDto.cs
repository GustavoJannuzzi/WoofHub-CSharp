using System.ComponentModel.DataAnnotations;

namespace WoofHub_App.Data.Dtos.AbandonmentReportDto
{
    public class CreateAbandonmentReportDto
    {
        [Required]
        public DateOnly? Date { get; set; }

        [Required]
        [StringLength(100)]
        public string? Animal { get; set; }

        [StringLength(5000, ErrorMessage = "A descrição deve ter no máximo 5000 carateres")]
        public string? Description { get; set; }
        
        public string? City { get; set; }
        [Required]
        [StringLength(155)]
        public string? Street { get; set; }
    }
}