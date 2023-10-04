using AutoMapper;
using WoofHub_App.Data.Dtos;
using WoofHub_App.Data.Dtos.EventDtos;
using WoofHub_App.Models;

namespace WoofHub_App.Profiles
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<CreateEventDto, EventModel>();
            CreateMap<UpdateEventDto, EventModel>();
            CreateMap<EventModel, UpdateEventDto>();
            CreateMap<EventModel, ReadEventDto>();
        }
    }
}