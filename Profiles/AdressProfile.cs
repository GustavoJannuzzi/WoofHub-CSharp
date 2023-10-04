using AutoMapper;
using WoofHub_App.Data.Dtos.AdressDto;
using WoofHub_App.Models;

namespace WoofHub_App.Profiles
{
    public class AdressProfile : Profile
    {
        public AdressProfile()
        {
            CreateMap<CreateAdressDto, AdressModel>();
            CreateMap<UpdateAdressDto, AdressModel>();
            CreateMap<AdressModel, ReadAdressDto>();
        }
    }
}