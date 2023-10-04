namespace WoofHub_App.Data.Dtos.EventDtos
{
    public class ReadEventDto
    {
        public required string NameEvent { get; set; }
        public DateOnly? DateEvent { get; set; }
        public string? Description { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
    }
}