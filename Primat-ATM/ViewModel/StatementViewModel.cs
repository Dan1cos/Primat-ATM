﻿using Primat_ATM.Model;
using Primat_ATM.Repository;
using Primat_ATM.ViewModel.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primat_ATM.ViewModel
{
    public class EnhancedTransaction
    {
        public DateTime Timestamp { get; set; }
        
        public string From { get; set; }
        public string To { get; set; }
        public float Amount { get; set; }
    }
    public class StatementViewModel: ViewModelBase
    {
        private int _selectedComboBoxId = 0;
        private INavigationService _navigationService;
        private ITransactionRepository transactionRepository;
        private ICardRepository cardRepository;
        private IList<EnhancedTransaction> _transactionList;
        public RelayCommand NavigateCancelCommand { get; set; }
        public ICardService CardService { get; set; }
        public StatementViewModel(INavigationService navigationService, ICardService cardService)
        {
            NavigationService = navigationService;
            CardService = cardService;
            transactionRepository = new TransactionRepository();
            cardRepository = new CardRepository();
            TransactionList = convertToEnhanced(transactionRepository.GetByToId(CardService.Card.CardId));

            NavigateCancelCommand = new RelayCommand(o => { NavigationService.NavigateTo<TransactionsViewModel>(); }, o => true);
        }

        public IList<EnhancedTransaction> convertToEnhanced(IList<Transaction> transactions)
        {
            IList<EnhancedTransaction> enhancedTransactions = new List<EnhancedTransaction>();
            foreach (Transaction transaction in transactions)
            {
                EnhancedTransaction trans = new EnhancedTransaction();
                trans.Timestamp = transaction.Timestamp;
                trans.To = cardRepository.GetById(transaction.ToId).CardNumber;
                if(trans.To == "0")
                {
                    trans.To = "Withdraw";
                }
                trans.From = cardRepository.GetById(transaction.FromId).CardNumber;
                if (trans.From == "0")
                {
                    trans.From = "Deposit";
                }
                trans.Amount = transaction.Amount;
                enhancedTransactions.Add(trans);
            }
            return enhancedTransactions;
        }

        public IList<EnhancedTransaction> TransactionList
        {
            get => _transactionList;
            set
            {
                _transactionList = value;
                OnPropertyChanged();
            }
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

        public int SelectedComboBoxId
        {
            get => _selectedComboBoxId;
            set
            {
                _selectedComboBoxId = value;
                switch (_selectedComboBoxId)
                {
                    case 1:
                        TransactionList = convertToEnhanced(transactionRepository.GetByFromId(CardService.Card.CardId));
                        break;
                    default:
                        TransactionList = convertToEnhanced(transactionRepository.GetByToId(CardService.Card.CardId));
                        break;
                }
            }
        }
    }
}
