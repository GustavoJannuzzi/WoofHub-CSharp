using AutoMapper;
using WoofHub_App.Data.Dtos;
using WoofHub_App.Data.Dtos.DonationDtos;
using WoofHub_App.Models;

namespace WoofHub_App.Profiles
{
    public class DonationProfile : Profile
    {
        public DonationProfile()
        {
            CreateMap<CreateDonationdto, DonationModel>();
            CreateMap<UpdateDonationDto, DonationModel>();
            CreateMap<DonationModel, UpdateDonationDto>();
        }
    }
}