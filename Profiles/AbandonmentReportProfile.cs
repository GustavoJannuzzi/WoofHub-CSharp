using AutoMapper;
using WoofHub_App.Data.Dtos.AbandonmentReportDto;
using WoofHub_App.Models;

namespace WoofHub_App.Profiles
{
    public class AbandonmentReportProfile : Profile
    {
        public AbandonmentReportProfile()
        {
            CreateMap<CreateAbandonmentReportDto, AbandonmentReportModel>();
            CreateMap<CreateAbandonmentReportDto, ReadAbandonmentAnimalDto>();
        }
    }
}