using Primat_ATM.ViewModel.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primat_ATM.ViewModel
{
    public class WithdrawViewModel: ViewModelBase
    {
        private INavigationService _navigationService;

        public RelayCommand NavigateOtherWithdrawWindowCommand { get; set; }
        public RelayCommand NavigateCancelCommand { get; set; }
        public WithdrawViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;

            NavigateOtherWithdrawWindowCommand = new RelayCommand(o => { NavigationService.NavigateTo<OtherWithdrawViewModel>(); }, o => true);
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
