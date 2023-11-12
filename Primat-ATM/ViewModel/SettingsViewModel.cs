using Primat_ATM.ViewModel.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primat_ATM.ViewModel
{
    public class SettingsViewModel : ViewModelBase
    {
        public ICardService CardService { get; set; }
        private INavigationService _navigationService;
        public RelayCommand NavigateChangeEmailWindowCommand { get; set; }
        public RelayCommand NavigateChangePasswordWindowCommand { get; set; }
        public RelayCommand NavigateCancelCommand { get; set; }
        public SettingsViewModel(INavigationService navigationService, ICardService cardService)
        {
            CardService = cardService;
            NavigationService = navigationService;

            NavigateChangeEmailWindowCommand = new RelayCommand(o => { NavigationService.NavigateTo<ChangeEmailViewModel>(); }, o => true);
            NavigateChangePasswordWindowCommand = new RelayCommand(o => { NavigationService.NavigateTo<ChangePasswordViewModel>(); }, o => true);
            NavigateCancelCommand = new RelayCommand(o => { NavigationService.NavigateTo<TransactionsViewModel>(); }, o => true);
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
