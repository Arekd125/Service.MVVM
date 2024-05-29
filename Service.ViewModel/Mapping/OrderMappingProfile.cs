using AutoMapper;
using Service.Model.Entity;
using Service.ViewModel.Dtos;
using Servis.Models.OrderModels;

namespace Service.ViewModel.Mapping
{
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<CreateOrderDto, Order>()
                .ForMember(dest => dest.Contact, opt => opt.MapFrom(src => new Contact
                {
                    Name = src.ContactName,
                    PhoneNumber = src.ContactPhoneNumber
                }));
            CreateMap<Order, DisplayOrderDto>()
                .ForMember(m => m.ContactName, c => c.MapFrom(s => s.Contact.Name))
                .ForMember(m => m.ContactPhoneNumber, c => c.MapFrom(s => s.Contact.PhoneNumber))
                .ForMember(m => m.StartData, c => c.MapFrom(s => s.StartDate.ToString("d")));

            CreateMap<Contact, ContactDto>()
                .ForMember(c => c.ContactName, z => z.MapFrom(s => s.Name));
            CreateMap<ContactDto, Contact>()
               .ForMember(c => c.Name, z => z.MapFrom(s => s.ContactName));

            CreateMap<DeviceStateDto, DeviceState>();
            CreateMap<ModelStateDto, ModelState>();
            CreateMap<ToDoState, ToDoStateDto>().ReverseMap();
            CreateMap<ToDoState, ToDoDto>().ReverseMap();
            CreateMap<ToDoDto, ToDo>();
        }
    }
}