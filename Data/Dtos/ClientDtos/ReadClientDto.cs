using System.Text.Json.Serialization;
using WoofHub_App.Data.Dtos.AdoptionDto;
using WoofHub_App.Data.Dtos.AdressDto;

namespace WoofHub_App.Data.Dtos.ClientDtos
{
    public class ReadClientDto
    {
        public int Id { get; set; }
        public string? ClientName { get; set; }
        public string? ClientCpf { get; set; }
        
        [JsonIgnore]
        public ReadAdressDto? Adress { get; set; }
        public ICollection<ReadAdoptionDto>? Adoption { get; set; }
    }
}