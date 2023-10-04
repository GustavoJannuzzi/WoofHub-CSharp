using System.ComponentModel.DataAnnotations;

namespace WoofHub_App.Models
{
    public class AdoptionModel
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public DateOnly DateAdoption { get; set; }

        [Required]
        public int ClientId { get; set; }
        public virtual ClientModel? Client { get; set; }

        [Required]
        public int AnimalId { get; set; }
        public virtual AnimalModel? Animal { get; set; }
    }
}