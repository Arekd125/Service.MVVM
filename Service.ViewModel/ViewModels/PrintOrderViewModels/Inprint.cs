using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel.ViewModels.PrintOrderViewModels
{
    public class Inprint
    {
        public string Name { get; }
        public string Street { get; }
        public string City { get; }
        public string Zipcode { get; }
        public string PhoneNumner1 { get; }
        public string? PhoneNumner2 { get; }
        public string? Mail { get; }

        public Inprint(string name, string street, string city, string zipcode, string phoneNumner1, string? phoneNumner2, string? mail)
        {
            Name = name;
            Street = street;
            City = city;
            Zipcode = zipcode;
            PhoneNumner1 = phoneNumner1;
            PhoneNumner2 = phoneNumner2;
            Mail = mail;
        }
    }
}