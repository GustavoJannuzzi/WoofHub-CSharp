using System.ComponentModel.DataAnnotations;

namespace WoofHub_App.Data.Dtos.ClientDtos
{
    public class UpdateClientDto
    {
        [Required]
        [StringLength(155, ErrorMessage = "O nome deve conter no máximo 155 caracteres")]
        public string? ClientName { get; set; }
        [Required]
        [StringLength(100)]
        public string? ClientCpf { get; set; }
    }
}