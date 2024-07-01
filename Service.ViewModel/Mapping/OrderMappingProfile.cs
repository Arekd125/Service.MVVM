using AutoMapper;
using Service.Model.Entity;
using Service.ViewModel.Dtos;
using Service.ViewModel.Service.Commands.CreateOrder;
using Service.ViewModel.Service.Commands.CreateToDoState;
using Service.ViewModel.Service.Commands.EditOrder;
using Service.ViewModel.Service.Commands.UpdateToDoState;
using Servis.Models.OrderModels;

namespace Service.ViewModel.Mapping
{
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<OrderDto, Order>()
                .ForMember(dest => dest.Contact, opt => opt.MapFrom(src => new Contact
                {
                    Name = src.ContactName,
                    PhoneNumber = src.ContactPhoneNumber
                })).ReverseMap();
            CreateMap<Order, OrderDto>()
                .ForMember(m => m.ContactName, c => c.MapFrom(s => s.Contact.Name))
                .ForMember(m => m.ContactPhoneNumber, c => c.MapFrom(s => s.Contact.PhoneNumber));

            CreateMap<OrderDto, CreateOrderCommand>();
            CreateMap<OrderDto, EditOrderCommand>();
            CreateMap<EditOrderCommand, Order>()
                .ForMember(dest => dest.Contact, opt => opt.MapFrom(src => new Contact
                {
                    Name = src.ContactName,
                    PhoneNumber = src.ContactPhoneNumber
                }));

            CreateMap<Contact, ContactDto>()
                .ForMember(c => c.ContactName, z => z.MapFrom(s => s.Name));
            CreateMap<ContactDto, Contact>()
               .ForMember(c => c.Name, z => z.MapFrom(s => s.ContactName));

            CreateMap<DeviceStateDto, DeviceState>();
            CreateMap<ModelStateDto, ModelState>();
            CreateMap<ToDoState, ToDoStateDto>().ReverseMap();
            CreateMap<ToDoState, ToDoDto>().ReverseMap();
            CreateMap<ToDoDto, ToDo>().ReverseMap();

            CreateMap<ToDoStateDto, CreateToDoStateCommand>();
            CreateMap<ToDoStateDto, UpdateToDoStateCommand>();
        }
    }
}