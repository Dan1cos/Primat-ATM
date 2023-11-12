﻿using Primat_ATM.Model;
using Primat_ATM.Repository;
using Primat_ATM.ViewModel.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Primat_ATM.ViewModel
{
    public class DepositViewModel: ViewModelBase
    {
        private float _amount;
        private INavigationService _navigationService;
        public RelayCommand NavigateCancelCommand { get; set; }
        public RelayCommand DepositCommand { get; set; }
        public ICardService CardService { get; set; }
        private ICardRepository cardRepository;
        private ITransactionRepository transactionRepository;
        public DepositViewModel(INavigationService navigationService, ICardService cardService)
        {
            NavigationService = navigationService;
            CardService = cardService;
            cardRepository = new CardRepository();
            transactionRepository = new TransactionRepository();

            NavigateCancelCommand = new RelayCommand(o => { NavigationService.NavigateTo<TransactionsViewModel>(); }, o => true);
            DepositCommand = new RelayCommand(ExecuteDepositCommand, CanExecuteDepositCommand);
        }

        public float Amount
        {
            get => _amount;
            set => _amount = value;
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

        private void ExecuteDepositCommand(object obj)
        {
            CardService.Card.Balance += Amount;
            cardRepository.Edit(CardService.Card);
            Transaction trans = new Transaction();
            trans.Amount = Amount;
            trans.FromId = 1;
            trans.ToId = CardService.Card.CardId;
            trans.Timestamp = DateTime.Now;
            transactionRepository.Add(trans);
            MessageBox.Show("Success");
            NavigationService.NavigateTo<TransactionsViewModel>();
        }

        private bool CanExecuteDepositCommand(object obj)
        {
            bool validData = false;
            if (!float.IsNaN(Amount) && !float.IsNegative(Amount) && Amount!=0)
            {
                validData = true;
            }
            return validData;
        }
    }
}
