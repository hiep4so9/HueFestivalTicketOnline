using AutoMapper;
using HueFestivalTicketOnline.Data;
using HueFestivalTicketOnline.Model;
using HueFestivalTicketOnline.Models;

namespace HueFestivalTicketOnline.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper() 
        {
            CreateMap<User,  UserDTO>().ReverseMap();
            CreateMap<EventType, EventTypeDTO>().ReverseMap();
            CreateMap<Event, EventDTO>().ReverseMap();
            CreateMap<Location, LocationDTO>().ReverseMap();
            CreateMap<News, NewsDTO>().ReverseMap();
            CreateMap<Artist, ArtistDTO>().ReverseMap();
            CreateMap<EventImage, EventImageDTO>().ReverseMap();
            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<TicketType, TicketTypeDTO>().ReverseMap();
            CreateMap<Ticket, TicketDTO>().ReverseMap();
        }
    }
}
