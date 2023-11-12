using Primat_ATM.Model;
using Primat_ATM.ViewModel.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primat_ATM.ViewModel
{
    public class MainViewModel:ViewModelBase
    {
        private Card card;
        private INavigationService _navigationService;
        private readonly IWindowManager _windowManager;
        private readonly ViewModelLocator _viewModelLocator;
        public ICardService CardService { get; set; }
        public RelayCommand EndSession { get; set; }


        public MainViewModel(INavigationService navigationService ,ICardService cardService, IWindowManager windowManager, ViewModelLocator viewModelLocator)
        {
            NavigationService = navigationService;
            CardService = cardService;
            _windowManager = windowManager;
            _viewModelLocator = viewModelLocator;
            card = cardService.Card;

            EndSession = new RelayCommand(o => { NavigationService.NavigateTo<TransactionsViewModel>(); }, o => true);

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
