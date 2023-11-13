using Primat_ATM.Model;
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
    public class OtherWithdrawViewModel: ViewModelBase
    {
        private float _amount;
        private INavigationService _navigationService;
        private ICardRepository cardRepository;
        private ITransactionRepository transactionRepository;
        private string errorMessage;
        public ICardService CardService { get; set; }
        public RelayCommand NavigateCancelCommand { get; set; }
        public RelayCommand WithdrawCommand { get; set; }
        public OtherWithdrawViewModel(INavigationService navigationService, ICardService cardService)
        {
            NavigationService = navigationService;
            cardRepository = new CardRepository();
            transactionRepository = new TransactionRepository();
            CardService = cardService;

            NavigateCancelCommand = new RelayCommand(o => { NavigationService.NavigateTo<WithdrawViewModel>(); }, o => true);
            WithdrawCommand = new RelayCommand(ExecuteWithdrawCommand, CanExecuteWithdrawCommand);
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

        public float Amount
        {
            get => _amount;
            set => _amount = value;
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

        private void ExecuteWithdrawCommand(object obj)
        {
            bool isValidSum = CardService.Card.Balance >= Amount;
            if (isValidSum)
            {
                CardService.Card.Balance -= Amount;
                cardRepository.Edit(CardService.Card);
                Transaction trans = new Transaction();
                trans.Amount = Amount;
                trans.FromId = CardService.Card.CardId;
                trans.ToId = 1;
                trans.Timestamp = DateTime.Now;
                transactionRepository.Add(trans);
                MessageBox.Show("Success");
                if (CardService.Card.SendNotification)
                {
                    EmailSender.SendEmail(CardService.Card.Email, "Withdraw from card", $"<div>{Amount} UAH were withdrawed from {CardService.Card.CardNumber}</div>");
                } 
                NavigationService.NavigateTo<TransactionsViewModel>();
            }
            else
            {
                ErrorMessage = "Insufficient sum";
            }
        }

        private bool CanExecuteWithdrawCommand(object obj)
        {
            bool validData = false;
            if (!float.IsNaN(Amount) && !float.IsNegative(Amount) && Amount != 0)
            {
                validData = true;
            }
            return validData;
        }
    }
}
