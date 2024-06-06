using Service.ViewModel.Dtos;
using Service.ViewModel.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModel.ViewModels
{
    public class OrderDetailsViewModel : ViewModelBase
    {
        private IEnumerable<ToDoDto> _todoTextBlock;

        public IEnumerable<ToDoDto> TodoTextBlock
        {
            get
            {
                return _todoTextBlock;
            }
            set
            {
                _todoTextBlock = value;
                OnPropertyChanged(nameof(TodoTextBlock));
            }
        }

        private string _descriptionTextBlock;

        public string DescriptionTextBlock
        {
            get
            {
                return _descriptionTextBlock;
            }
            set
            {
                _descriptionTextBlock = value;
                OnPropertyChanged(nameof(DescriptionTextBlock));
            }
        }

        private string _accessoriesTexBox;

        public string AccessoriesTexBox
        {
            get
            {
                return _accessoriesTexBox;
            }
            set
            {
                _accessoriesTexBox = value;
                OnPropertyChanged(nameof(AccessoriesTexBox));
            }
        }

        private readonly OrderStore _orderStore;

        public OrderDetailsViewModel(OrderStore orderStore)
        {
            _orderStore = orderStore;
            _orderStore.OrderDetails += OnOrderDetails;
        }

        private void OnOrderDetails(OrderDto orderDto)
        {
            TodoTextBlock = orderDto.ToDo;
            DescriptionTextBlock = orderDto.Description;
            AccessoriesTexBox = orderDto.Accessories;
        }

        public override void Dispose()
        {
            _orderStore.OrderDetails -= OnOrderDetails;

            base.Dispose();
        }
    }
}