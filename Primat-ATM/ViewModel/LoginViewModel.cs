﻿using Primat_ATM.Model;
using Primat_ATM.Repository;
using Primat_ATM.ViewModel.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Primat_ATM.ViewModel
{
    public class LoginViewModel: ViewModelBase
    {
        private Card card;
        private ICardRepository cardRepository;
        private string errorMessage;
        private IWindowManager _windowManager;
        private ViewModelLocator _viewModelLocator;
        private INavigationService _navigationService;
        public ICardService CardService { get; set; }
        public LoginViewModel(INavigationService navigationService, ICardService cardService, IWindowManager windowManager, ViewModelLocator viewModelLocator)
        {
            cardRepository = new CardRepository();
            card = new Card();
            CardService = cardService;
            _windowManager = windowManager;
            _viewModelLocator = viewModelLocator;
            NavigationService = navigationService;

            LoginCommand = new RelayCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
        }

        public ICommand LoginCommand { get; }

        public INavigationService NavigationService
        {
            get => _navigationService;
            set
            {
                _navigationService = value;
                OnPropertyChanged();
            }
        }

        public string CardNumber
        {
            get => card.CardNumber;
            set => card.CardNumber = value;
        }

        public string Pin
        {
            get => card.Pin;
            set => card.Pin = value;
        }

        public string ErrorMessage
        {
            get => errorMessage;
            set
            {
                errorMessage = value;
                OnPropertyChanged("ErrorMessage");
            }
        }


        private void ExecuteLoginCommand(object obj)
        {
            bool isCardReal = cardRepository.GetByCardNumber(CardNumber)!=null;
            if (isCardReal)
            {
                var isValidCard = cardRepository.AuthenticateCard(new NetworkCredential(CardNumber, Pin));
                if (isValidCard)
                {
                    CardService.Authenticate(cardRepository.GetByCardNumber(CardNumber));
                    NavigationService.NavigateTo<TransactionsViewModel>();
                    ErrorMessage = "";
                    _windowManager.ShowDialog(_viewModelLocator.MainViewModel);
                }
                else
                {
                    ErrorMessage = "Wrong Pin";
                }
            }
            else
            {
                ErrorMessage = "Card is unreal";
            }
        }

        private bool CanExecuteLoginCommand(object obj)
        {
            return !string.IsNullOrWhiteSpace(CardNumber) && CardNumber.Length == 16 && CardNumber.All(char.IsDigit) && !string.IsNullOrWhiteSpace(Pin) && Pin.Length == 4 && Pin.All(char.IsDigit);
        }
    }
}
