using System.ComponentModel.DataAnnotations;

namespace WoofHub_App.Data.Dtos.AdoptionDto
{
    public class UpdateAdoptionDto
    {
        [Required]
        public DateTime DateAdoption { get; set; }
    }
}