﻿using Primat_ATM.Model;
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
        public RelayCommand OpenSettingsWindowCommand { get; set; }
        public RelayCommand NavigateDepositCommand { get; set; }
        public RelayCommand NavigateTransferCommand { get; set; }
        public RelayCommand NavigateWithdrawalCommand { get; set; }
        public RelayCommand RelayNavigateCancelCommand { get; set; }

        public MainViewModel(INavigationService navigationService ,ICardService cardService, IWindowManager windowManager, ViewModelLocator viewModelLocator)
        {
            NavigationService = navigationService;
            CardService = cardService;
            _windowManager = windowManager;
            _viewModelLocator = viewModelLocator;
            card = cardService.Card;

            OpenSettingsWindowCommand = new RelayCommand(o => { _windowManager.ShowWindow(_viewModelLocator.SettingsViewModel); }, o => true);
            //NavigateDepositCommand = new RelayCommand(o => { NavigationService.NavigateTo<DepositViewModel>(); }, o => true);
            NavigateDepositCommand = new RelayCommand(o => { _windowManager.ShowWindow(_viewModelLocator.DepositViewModel); }, o => true);

            //NavigateTransferCommand = new RelayCommand(o => { NavigationService.NavigateTo<TransferViewModel>(); }, o => true);
            NavigateTransferCommand = new RelayCommand(o => { _windowManager.ShowWindow(_viewModelLocator.TransferViewModel); }, o => true);

            //NavigateWithdrawalCommand = new RelayCommand(o => { NavigationService.NavigateTo<WithdrawalViewModel>(); }, o => true);
            NavigateWithdrawalCommand = new RelayCommand(o => { _windowManager.ShowWindow(_viewModelLocator.WithdrawalViewModel); }, o => true);

        }

        public string CardNumber
        {
            get => card.CardNumber;
            set => card.CardNumber = value;
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
