using Primat_ATM.ViewModel.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primat_ATM.ViewModel
{
    public class ChangeEmailViewModel:ViewModelBase
    {
        private INavigationService _navigationService;
        public RelayCommand NavigateCancelCommand { get; set; }
        public ChangeEmailViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;

            NavigateCancelCommand = new RelayCommand(o => { NavigationService.NavigateTo<SettingsViewModel>(); }, o => true);
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
