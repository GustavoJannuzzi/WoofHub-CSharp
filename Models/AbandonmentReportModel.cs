using System.ComponentModel.DataAnnotations;

namespace WoofHub_App.Models
{
    public class AbandonmentReportModel
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public DateOnly? Date { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Animal { get; set; }

        [MaxLength(5000, ErrorMessage = "A descrição deve ter no máximo 5000 carateres")]
        public string? Description { get; set; }
        
        [Required]
        [MaxLength(155)]
        public string? City { get; set; }
        [Required]
        [MaxLength(155)]
        public string? Street { get; set; }
    }
}
