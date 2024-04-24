using AutoMapper;
using Service.ViewModel.Dtos;
using Servis.Models.OrderModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel.Mapping
{
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<CreateOrderDto, Order>()
                .ForMember(e => e.Contact, opt => opt.MapFrom(src => new Contact()
                {
                    Name = src.ContactName,
                    PhoneNumber = src.ContactPhoneNumber
                }));

            CreateMap<Order, DisplayOrderDto>()
                .ForMember(m => m.ContactName, c => c.MapFrom(s => s.Contact.Name))
                .ForMember(m => m.ContactPhoneNumber, c => c.MapFrom(s => s.Contact.PhoneNumber))
                .ForMember(m => m.StartData, c => c.MapFrom(s => s.StartDate.ToString("d")));
        }
    }
}