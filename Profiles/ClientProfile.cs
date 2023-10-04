using AutoMapper;
using WoofHub_App.Data.Dtos;
using WoofHub_App.Data.Dtos.ClientDtos;
using WoofHub_App.Models;

namespace WoofHub_App.Profiles
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<CreateClientDto, ClientModel>();
            CreateMap<UpdateClientDto, ClientModel>();
            CreateMap<ClientModel, UpdateClientDto>();
            CreateMap<ClientModel, ReadClientDto>()
                .ForMember(clientDto => clientDto.Adress,
                    opt => opt.MapFrom(client => client.Adress))
                .ForMember(clientDto => clientDto.Adoption,
                    opt => opt.MapFrom(client => client.Adoptions)); ;
        }
    }
}