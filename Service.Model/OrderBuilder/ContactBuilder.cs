using Servis.Models.OrderModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servis.Models.OrderBuilder
{
    public class ContactBuilder
    {
        private Contact _contact = new Contact();

        public ContactBuilder(string contactName, string phone)
        {
            _contact.Name = contactName;
            _contact.PhoneNumber = phone;
        }

        public Contact Build()
        {
            return _contact;
        }
    }
}