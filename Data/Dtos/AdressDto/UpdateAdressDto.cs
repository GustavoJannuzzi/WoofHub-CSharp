using System.ComponentModel.DataAnnotations;

namespace WoofHub_App.Data.Dtos.AdressDto
{
    public class UpdateAdressDto
    {
        [Required]
        [StringLength(155, ErrorMessage = "Tamanho máximo do campo de 155 caracteres")]
        public string? Country { get; set; }

        [Required]
        [StringLength(155, ErrorMessage = "Tamanho máximo do campo de 155 caracteres")]
        public string? City { get; set; }

        [Required]
        [StringLength(155, ErrorMessage = "Tamanho máximo do campo de 155 caracteres")]
        public string? State { get; set; }

        [Required]
        [StringLength(155, ErrorMessage = "Tamanho máximo do campo de 155 caracteres")]
        public string? Street { get; set; }

        [Required]
        public int Number { get; set; }

        [Required]
        [StringLength(155, ErrorMessage = "Tamanho máximo do campo de 155 caracteres")]
        public string? Cep { get; set; }
    }
}