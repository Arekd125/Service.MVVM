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
        private bool Refresh = true;

        private void SelectContactNameSelectedItem()
        {
            if (Refresh)
            {
                ContactNameSelectedItem = AllContacts.FirstOrDefault(p => p.PhoneNumber == ContactPhoneNumberSelectedItem)?.ContactName;
            }
        }

        private void SelectContactPhoneNumberSelectedItem()
        {
            if (Refresh)
            {
                ContactPhoneNumberSelectedItem = AllContacts.Where(p => p.ContactName == ContactNameSelectedItem).Select(p => p.PhoneNumber).FirstOrDefault();
                if (ContactPhoneNumberSelectedItem != null)
                {
                    ContactPhoneNumberComboBox = ContactPhoneNumberSelectedItem;
                }
            }
        }

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
                SelectContactPhoneNumberSelectedItem();
            }
        }

        private IEnumerable<string> _contactNameItemSource;

        public IEnumerable<string> ContactNameItemSource
        {
            get
            {
                return _contactNameItemSource;
            }
            set
            {
                _contactNameItemSource = value;
                OnPropertyChanged(nameof(ContactNameItemSource));
            }
        }

        private string? _contactNameSelectedItem;

        public string? ContactNameSelectedItem
        {
            get
            {
                return _contactNameSelectedItem;
            }
            set
            {
                _contactNameSelectedItem = value;
                OnPropertyChanged(nameof(ContactNameSelectedItem));
            }
        }

        private string _contactPhoneNumber = string.Empty;

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
                SelectContactNameSelectedItem();
            }
        }

        private IEnumerable<string> _contactPhoneNumberItemSource;

        public IEnumerable<string> ContactPhoneNumberItemSource
        {
            get
            {
                return _contactPhoneNumberItemSource;
            }
            set
            {
                _contactPhoneNumberItemSource = value;
                OnPropertyChanged(nameof(ContactPhoneNumberItemSource));
            }
        }

        private string? _contactPhoneNumberSelectedItem;

        public string? ContactPhoneNumberSelectedItem
        {
            get

            {
                return _contactPhoneNumberSelectedItem;
            }
            set
            {
                _contactPhoneNumberSelectedItem = value;

                OnPropertyChanged(nameof(ContactPhoneNumberSelectedItem));
            }
        }

        public ContactViewModel(IOrderService orderService)
        {
            _orderService = orderService;
            RefreshContactsItemSorce();
        }

        public void ClearContacts()
        {
            Refresh = false;
            ContactNameComboBox = string.Empty;
            ContactPhoneNumberComboBox = string.Empty;
            Refresh = true;
        }

        public void RefreshContactsItemSorce()
        {
            AllContacts = _orderService.GetAllContacts().Result;
            ContactNameItemSource = AllContacts.Where(p => !string.IsNullOrEmpty(p.ContactName)).Select(p => p.ContactName);
            ContactPhoneNumberItemSource = AllContacts.Select(p => p.PhoneNumber);
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