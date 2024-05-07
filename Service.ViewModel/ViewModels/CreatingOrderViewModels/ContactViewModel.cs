using Service.ViewModel.Dtos;
using Service.ViewModel.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Service.ViewModel.ViewModels.CreatingOrderViewModels
{
    public class ContactViewModel : ViewModelBase
    {
        private readonly IOrderService _orderService;

        private IEnumerable<ContactDto> AllContacts;

        private string _contactName = string.Empty;

        public string ContactNameComboBox
        {
            get
            {
                return _contactName;
            }
            set
            {
                _contactName = value;
                OnPropertyChanged(nameof(ContactNameComboBox));
            }
        }

        private IEnumerable<string> _contactNameItemSource;

        public IEnumerable<string> ContactNameItemSource
        {
            get
            {
                _contactNameItemSource = AllContacts.Where(p => !string.IsNullOrEmpty(p.ContactName)).Select(p => p.ContactName);
                return _contactNameItemSource;
            }
            set
            {
                _contactNameItemSource = value;
                OnPropertyChanged(nameof(ContactNameItemSource));
            }
        }

        private string _contactNameSelectedItem;

        public string ContactNameSelectedItem
        {
            get
            {
                return _contactNameSelectedItem;
            }
            set
            {
                _contactNameSelectedItem = value;
                OnPropertyChanged(nameof(ContactNameSelectedItem));
                //if (string.IsNullOrEmpty(ContactPhoneNumberSelectedItem))
                //{
                //    ContactPhoneNumberSelectedItem = AllContacts.Where(p => p.ContactName == ContactNameSelectedItem).Select(p => p.PhoneNumber).FirstOrDefault();
                //    //  ContactPhoneNumberComboBox = ContactPhoneNumberSelectedItem;
                //}
            }
        }

        private string _contactPhoneNumber = "";

        public string ContactPhoneNumberComboBox
        {
            get
            {
                return _contactPhoneNumber;
            }
            set
            {
                _contactPhoneNumber = PhoneValisation(value);

                OnPropertyChanged(nameof(ContactPhoneNumberComboBox));
            }
        }

        private IEnumerable<string> _contactPhoneNumberItemSource;

        public IEnumerable<string> ContactPhoneNumberItemSource
        {
            get
            {
                _contactPhoneNumberItemSource = AllContacts.Select(p => p.PhoneNumber);
                return _contactPhoneNumberItemSource;
            }
            set
            {
                _contactPhoneNumberItemSource = value;
                OnPropertyChanged(nameof(ContactPhoneNumberItemSource));
            }
        }

        private string _contactPhoneNumberSelectedItem;

        public string ContactPhoneNumberSelectedItem
        {
            get

            {
                return _contactPhoneNumberSelectedItem;
            }
            set
            {
                _contactPhoneNumberSelectedItem = value;

                OnPropertyChanged(nameof(ContactPhoneNumberSelectedItem));
                if (string.IsNullOrEmpty(ContactNameSelectedItem))
                    ContactNameSelectedItem = AllContacts.FirstOrDefault(p => p.PhoneNumber == ContactPhoneNumberSelectedItem)?.ContactName;
            }
        }

        public ContactViewModel(IOrderService orderService)
        {
            _orderService = orderService;
            RefreshContacts();
        }

        public void RefreshContacts()
        {
            AllContacts = _orderService.GetAllContacts().Result;
        }

        //public string PhoneValisation(string phoneNumber)
        //{
        //    if (phoneNumber == null)
        //        return "";
        //    if (phoneNumber.Length > 11)
        //    {
        //        return phoneNumber[0..11];
        //    }

        //    var isNotNumber = new Regex("[^0-9 ]").IsMatch(phoneNumber);
        //    if (isNotNumber)
        //    {
        //        var result = phoneNumber[0..^1];
        //        return result;
        //    }

        //    return Regex.Replace(phoneNumber, "(\\d{3})(?=\\d)", "$1 "); ;
        //}

        private string PhoneValisation(string PhoneNumber)
        {
            if (PhoneNumber.Length > 11)
            {
                return PhoneNumber.Substring(0, 11);
            }

            string cleanedPhoneNumber = Regex.Replace(PhoneNumber, "[^0-9]+", "");
            string formattedNumber = "";

            for (int i = 0; i < cleanedPhoneNumber.Length; i++)
            {
                if (i > 0 && i % 3 == 0)  // Dodawanie spacji co trzy znaki
                {
                    formattedNumber += " ";
                }
                formattedNumber += cleanedPhoneNumber[i];
            }
            return formattedNumber;
        }
    }
}