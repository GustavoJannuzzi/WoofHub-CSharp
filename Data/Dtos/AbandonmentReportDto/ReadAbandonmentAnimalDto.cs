using WoofHub_App.Models;

namespace WoofHub_App.Data.Dtos.AbandonmentReportDto
{
    public class ReadAbandonmentAnimalDto
    {
        public int Id { get; set; }
        public DateOnly? Date { get; set; }
        public string? Animal { get; set;}
        public string? Description { get; set; }
        //public virtual AdressModel? Adress { get; set; }
    }
}