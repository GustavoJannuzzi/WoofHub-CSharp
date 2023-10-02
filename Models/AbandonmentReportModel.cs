using System.ComponentModel.DataAnnotations;

namespace WoofHub_App.Models
{
    public class AbandonmentReportModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateOnly? Date { get; set; }
        [Required]
        public required AdressModel AbandonmentAdress { get; set; }
        public string? Description { get; set; }
    }
}
