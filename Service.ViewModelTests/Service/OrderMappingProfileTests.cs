﻿using AutoMapper;
using FluentAssertions;
using Service.ViewModel.Dtos;
using Service.ViewModel.Mapping;
using Servis.Models.OrderModels;
using Xunit;

namespace Service.ViewModelTests.Service
{
    public class OrderMappingProfileTests
    {
        [Fact()]
        public void MappingProfile_ShouldMapCreateOrderDtoToOrder()
        {
            // arrange

            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new OrderMappingProfile()));
            var mapper = configuration.CreateMapper();

            OrderDto Dto = new()
            {
                ContactName = "Contact Name",
                ContactPhoneNumber = "999 999 999"
            };

            // act

            var result = mapper.Map<Order>(Dto);

            // assert

            result.Should().NotBeNull();
            result.Contact.Should().NotBeNull();
            result.Contact.Name.Should().Be(Dto.ContactName);
            result.Contact.PhoneNumber.Should().Be(Dto.ContactPhoneNumber);
        }

        [Fact()]
        public void MappingProfile_ShouldMapOrderToDisplayOrderDto()
        {
            // arrange

            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new OrderMappingProfile()));
            var mapper = configuration.CreateMapper();

            Order order = new()
            {
                Contact = new Contact
                {
                    Name = "Name Test",
                    PhoneNumber = "111 111 111"
                },
                StartDate = DateTime.Now,
            };

            var DateString = order.StartDate.ToString($"dd.MM.yyyy");

            // act

            var result = mapper.Map<OrderDto>(order);

            // assert

            result.Should().NotBeNull();
            result.ContactName.Should().NotBeNull();
            result.ContactPhoneNumber.Should().NotBeNull();
            result.ContactName.Should().Be(order.Contact.Name);
            result.ContactPhoneNumber.Should().Be(order.Contact.PhoneNumber);
        }

        [Fact()]
        public void MappingProfile_ShouldMapContactToContactDto()
        {
            // arrange

            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new OrderMappingProfile()));
            var mapper = configuration.CreateMapper();

            Contact contact = new Contact
            {
                Name = "Test",
                PhoneNumber = "111 111 111"
            };

            // act

            var result = mapper.Map<ContactDto>(contact);

            // assert

            result.Should().NotBeNull();
            result.PhoneNumber.Should().NotBeNull();
            result.ContactName.Should().Be(contact.Name);
        }

        [Fact()]
        public void MappingProfile_ShouldMapContactDtoToContact()
        {
            // arrange

            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new OrderMappingProfile()));
            var mapper = configuration.CreateMapper();

            ContactDto Dto = new()
            {
                PhoneNumber = "111 111 111"
            };

            // act

            var result = mapper.Map<Contact>(Dto);

            // assert

            result.Should().NotBeNull();
            result.PhoneNumber.Should().NotBeNull();
            result.PhoneNumber.Should().Be(Dto.PhoneNumber);
        }
    }
}