using Primat_ATM.Model;
using Primat_ATM.ViewModel.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primat_ATM.ViewModel
{
    public class TransactionsViewModel: ViewModelBase
    {
        private Card card;
        private INavigationService _navigationService;
        private readonly IWindowManager _windowManager;
        private readonly ViewModelLocator _viewModelLocator;
        public ICardService CardService { get; set; }

        public RelayCommand NavigateWithdrawWindowCommand { get; set; }
        public RelayCommand NavigateDepositWindowCommand { get; set; }
        public RelayCommand NavigateTransferWindowCommand { get; set; }
        public RelayCommand NavigateSettingsWindowCommand { get; set; }
        public RelayCommand NavigateBalanceWindowCommand { get; set; }
        public RelayCommand NavigateStatementWindowCommand { get; set; }
        public RelayCommand EndSession { get; set; }


        public TransactionsViewModel(INavigationService navigationService, ICardService cardService, IWindowManager windowManager, ViewModelLocator viewModelLocator)
        {
            NavigationService = navigationService;
            CardService = cardService;
            _windowManager = windowManager;
            _viewModelLocator = viewModelLocator;
            card = cardService.Card;


            NavigateWithdrawWindowCommand = new RelayCommand(o => { NavigationService.NavigateTo<WithdrawViewModel>(); }, o => true);
            NavigateDepositWindowCommand = new RelayCommand(o => { NavigationService.NavigateTo<DepositViewModel>(); }, o => true);
            NavigateTransferWindowCommand = new RelayCommand(o => { NavigationService.NavigateTo<TransferViewModel>(); }, o => true);
            NavigateSettingsWindowCommand = new RelayCommand(o => { NavigationService.NavigateTo<SettingsViewModel>(); }, o => true);
            NavigateBalanceWindowCommand = new RelayCommand(o => { NavigationService.NavigateTo<BalanceViewModel>(); }, o => true);
            NavigateStatementWindowCommand = new RelayCommand(o => { NavigationService.NavigateTo<StatementViewModel>(); }, o => true);
        }

        public INavigationService NavigationService
        {
            get => _navigationService;
            set
            {
                _navigationService = value;
                OnPropertyChanged();
            }
        }
    }
}
