using MediatR;
using Service.ViewModel.Commands.StatusBarCommand;
using Service.ViewModel.Service;
using Service.ViewModel.Service.Queries.GetNumberOpenedOrders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Service.ViewModel.ViewModels.StatusBarViewVModels
{
    public class StatusBarViewModel : ViewModelBase
    {
        private readonly IMediator _mediator;

        public ICommand InfoButton { get; }
        public ICommand SettingsButton { get; }
        private int _openedOrders;

        public int OpenedOrders
        {
            get
            {
                _openedOrders = GetNumberOpenedOrders();
                return _openedOrders;
            }
            set
            {
                _openedOrders = value;
                OnPropertyChanged(nameof(OpenedOrders));
            }
        }

        public StatusBarViewModel(IMediator mediator, IDialogService dialogService, InfoViewModel infoViewModel, SettingsViewModel settingsViewModel)
        {
            _mediator = mediator;
            InfoButton = new InfoButtonCommand(dialogService, infoViewModel);
            SettingsButton = new SettingsButtonCommand(dialogService, settingsViewModel);
        }

        public int GetNumberOpenedOrders()
        {
            return _mediator.Send(new GetNumberOpenedOrdersQuery()).Result;
        }
    }
}