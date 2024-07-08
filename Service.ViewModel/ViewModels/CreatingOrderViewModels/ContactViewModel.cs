using MediatR;
using Service.ViewModel.Dtos;
using Service.ViewModel.Service.Queries.GetAllContacts;
using System.Text.RegularExpressions;

namespace Service.ViewModel.ViewModels.CreatingOrderViewModels
{
    public class ContactViewModel : ViewModelBase
    {
        private readonly IMediator _mediator;

        private string _contactNameComboBox = default!;
        private IEnumerable<string?>? _contactNameItemSource;
        private string? _contactNameSelectedItem;
        private string _contactPhoneNumber = default!;
        private IEnumerable<string>? _contactPhoneNumberItemSource;
        private string? _contactPhoneNumberSelectedItem;
        private IEnumerable<ContactDto> AllContacts;

        public ContactViewModel(IMediator mediator)
        {
            _mediator = mediator;
            AllContacts = new List<ContactDto>();
            RefreshContactsItemSorce();
        }

        public string ContactNameComboBox
        {
            get
            {
                return _contactNameComboBox;
            }
            set
            {
                _contactNameComboBox = value;
                OnPropertyChanged(nameof(ContactNameComboBox));
                SelectContactPhoneNumberSelectedItem();
            }
        }

        public IEnumerable<string?>? ContactNameItemSource
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

        public IEnumerable<string>? ContactPhoneNumberItemSource
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

        public void Clear()
        {
            RefreshContactsItemSorce();
            ContactNameComboBox = string.Empty;
            ContactPhoneNumberComboBox = string.Empty;
        }

        public void RefreshContactsItemSorce()
        {
            AllContacts = _mediator.Send(new GetAllContactsQuery()).Result;
            ContactNameItemSource = AllContacts.Where(p => !string.IsNullOrEmpty(p.ContactName)).Select(p => p.ContactName);
            ContactPhoneNumberItemSource = AllContacts.Select(p => p.PhoneNumber);
        }

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
                if (i > 0 && i % 3 == 0)
                {
                    formattedNumber += " ";
                }
                formattedNumber += cleanedPhoneNumber[i];
            }
            return formattedNumber;
        }

        private void SelectContactNameSelectedItem()
        {
            ContactNameSelectedItem = AllContacts.FirstOrDefault(p => p.PhoneNumber == ContactPhoneNumberSelectedItem)?.ContactName;
        }

        private void SelectContactPhoneNumberSelectedItem()
        {
            ContactPhoneNumberSelectedItem = AllContacts.Where(p => p.ContactName == ContactNameSelectedItem && !string.IsNullOrEmpty(ContactNameSelectedItem)).Select(p => p.PhoneNumber).FirstOrDefault();
            if (ContactPhoneNumberSelectedItem != null)
            {
                ContactPhoneNumberComboBox = ContactPhoneNumberSelectedItem;
            }
        }
    }
}