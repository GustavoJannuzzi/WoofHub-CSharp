using System.ComponentModel.DataAnnotations;

namespace WoofHub_App.Models
{
    public class AdressModel
    {
        [Key]
        public int Id { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Street { get; set; }
        public string? Number { get; set; }
        public string? Cep { get; set; }
    }
}