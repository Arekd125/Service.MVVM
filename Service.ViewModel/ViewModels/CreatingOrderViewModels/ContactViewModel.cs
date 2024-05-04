using Service.ViewModel.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Service.ViewModel.ViewModels.CreatingOrderViewModels
{
    public class ContactViewModel : ViewModelBase
    {
        
        private string _contactName = string.Empty;

        public string ContactNameTextBox
        {
            get
            {
                return _contactName;
            }
            set
            {
                _contactName = value;
                OnPropertyChanged(nameof(ContactNameTextBox));
            }
        }

        private string _contactPhoneNumber = string.Empty;

        public string ContactPhoneNumberTextBox
        {
            get
            {
                return _contactPhoneNumber;
            }
            set
            {
                _contactPhoneNumber =  PhoneValisation(value);

                OnPropertyChanged(nameof(ContactPhoneNumberTextBox));
            }
        }
        public string PhoneValisation(string phoneNumber)
        {
            if (phoneNumber.Length > 11)
            {
                return phoneNumber[0..11];
            }

            var isNotNumber = new Regex("[^0-9 ]").IsMatch(phoneNumber);
            if (isNotNumber)
            {
                var result = phoneNumber[0..^1];
                return result;
            }

            return Regex.Replace(phoneNumber, "(\\d{3})(?=\\d)", "$1 "); ;
        }
    }
}