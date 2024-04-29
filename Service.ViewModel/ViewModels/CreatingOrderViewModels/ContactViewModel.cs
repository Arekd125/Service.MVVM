using Service.ViewModel.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Service.ViewModel.ViewModels.CreatingOrderViewModels
{
    public class ContactViewModel
    {
        private readonly CreatingOrderViewModel _creatingOrderViewModel;
        private readonly IOrderService _orderService;

        public ContactViewModel(CreatingOrderViewModel creatingOrderViewModel, IOrderService orderService)
        {
            _creatingOrderViewModel = creatingOrderViewModel;
            _orderService = orderService;
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