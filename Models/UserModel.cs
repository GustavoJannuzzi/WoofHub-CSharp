using System.ComponentModel.DataAnnotations;

namespace WoofHub_App.Models
{
    public class UserModel
    {   
        [Key]
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set;}
        public string? Password { get; set; }
    }
}