namespace WoofHub_App.Data.Dtos.AdressDto
{
    public class ReadAdressDto
    {
        public int Id { get; set; }
        public string? Country { get; set; }
        public string? State { get; set; }
        public string? City { get; set; }
        public string? Cep { get; set; }
        public string? Street { get; set; }
        public int Number { get; set; }
    }
}