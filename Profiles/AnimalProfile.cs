using AutoMapper;
using WoofHub_App.Data.Dtos;
using WoofHub_App.Data.Dtos.AnimalDtos;
using WoofHub_App.Models;

namespace WoofHub_App.Profiles
{
    public class AnimalProfile : Profile
    {
        public AnimalProfile()
        {
            CreateMap<CreateAnimalDto, AnimalModel>();
            CreateMap<UpdateAnimalDto, AnimalModel>();
            CreateMap<AnimalModel, UpdateAnimalDto>();
            CreateMap<AnimalModel, ReadAnimalDto>()
                .ForMember(animalDto => animalDto.Adoption,
                    opt => opt.MapFrom(animal => animal.Adoptions));
        }
    }
}