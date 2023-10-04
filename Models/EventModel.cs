using System.ComponentModel.DataAnnotations;

namespace WoofHub_App.Models
{
    public class EventModel
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100, ErrorMessage = "O evento deve ter no máximo 100 caractereres")]
        public required string NameEvent { get; set; }
        public DateOnly? DateEvent { get; set; }

        [MaxLength(5000, ErrorMessage = "A descrição deve ter no máximo 5000 caractereres")]
        public string? Description { get; set; }

        [Required]
        [MaxLength(155)]
        public string? City { get; set; }
        [Required]
        [MaxLength(155)]
        public string? Street { get; set; }
    }
}