using System.ComponentModel.DataAnnotations;

namespace WoofHub_App.Data.Dtos
{
    public class CreateUserDto
    {
        [Required]
        [StringLength(155, ErrorMessage = "O nome deve conter no máximo 155 caracteres")]
        public string? UserName { get; set; }

        [Required]
        [StringLength(155)]
        public string? Email { get; set; }
        [Required]
        [StringLength(155)]
        public string? Password { get; set; }
    }
}