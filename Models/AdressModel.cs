using System.ComponentModel.DataAnnotations;

namespace WoofHub_App.Models
{
    public class AdressModel
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(155, ErrorMessage = "Tamanho máximo do campo de 155 caracteres")]
        public string? Country { get; set; }

        [Required]
        [MaxLength(155, ErrorMessage = "Tamanho máximo do campo de 155 caracteres")]
        public string? State { get; set; }

        [Required]
        [MaxLength(155, ErrorMessage = "Tamanho máximo do campo de 155 caracteres")]
        public string? City { get; set; }

        [Required]
        [MaxLength(155, ErrorMessage = "Tamanho máximo do campo de 155 caracteres")]
        public string? Cep { get; set; }

        [Required]
        [MaxLength(155, ErrorMessage = "Tamanho máximo do campo de 155 caracteres")]
        public string? Street { get; set; }

        [Required]
        public int Number { get; set; }
        public virtual ClientModel? Client { get; set; }
        public virtual AbandonmentReportModel? Abandonment { get; set; }
    }
}