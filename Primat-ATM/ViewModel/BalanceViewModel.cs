using Primat_ATM.ViewModel.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primat_ATM.ViewModel
{
    public class BalanceViewModel: ViewModelBase
    {
        private INavigationService _navigationService;
        public RelayCommand NavigateCancelCommand { get; set; }
        public ICardService CardService { get; set; }
        public BalanceViewModel(INavigationService navigationService, ICardService cardService)
        {
            NavigationService = navigationService;
            CardService = cardService;

            NavigateCancelCommand = new RelayCommand(o => { NavigationService.NavigateTo<TransactionsViewModel>(); }, o => true);
        }

        public float Amount
        {
            get => CardService.Card.Balance;
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
