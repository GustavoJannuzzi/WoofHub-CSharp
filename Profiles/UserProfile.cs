using AutoMapper;
using WoofHub_App.Data.Dtos;
using WoofHub_App.Data.Dtos.UserDtos;
using WoofHub_App.Models;

namespace WoofHub_App.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserDto, UserModel>();
            CreateMap<UpdateUserDto, UserModel>();
            CreateMap<UserModel, UpdateUserDto>();
        }
    }
}