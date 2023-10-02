using System.ComponentModel.DataAnnotations;

namespace WoofHub_App.Models
{
    public class DonationModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public float? Value { get; set; }
        [Required]
        public string? Description { get; set; }
    }
}
