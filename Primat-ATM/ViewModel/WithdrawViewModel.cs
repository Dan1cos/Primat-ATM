using Primat_ATM.Model;
using Primat_ATM.Repository;
using Primat_ATM.View;
using Primat_ATM.ViewModel.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Primat_ATM.ViewModel
{
    public class WithdrawViewModel: ViewModelBase
    {
        private INavigationService _navigationService;
        private ICardRepository cardRepository;
        private ITransactionRepository transactionRepository;
        public ICardService CardService { get; set; }
        public RelayCommand NavigateOtherWithdrawWindowCommand { get; set; }
        public RelayCommand NavigateCancelCommand { get; set; }
        public RelayCommand WithdrawCommand { get; set; }
        private ConfirmationDialog _dialog;
        public WithdrawViewModel(INavigationService navigationService, ICardService cardService)
        {
            NavigationService = navigationService;
            cardRepository = new CardRepository();
            transactionRepository = new TransactionRepository();
            CardService = cardService;
            _dialog = new ConfirmationDialog();

            NavigateOtherWithdrawWindowCommand = new RelayCommand(o => { NavigationService.NavigateTo<OtherWithdrawViewModel>(); }, o => true);
            NavigateCancelCommand = new RelayCommand(o => { NavigationService.NavigateTo<TransactionsViewModel>(); }, o => true);
            WithdrawCommand = new RelayCommand(ExecuteWithdrawCommand);
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

        private void ExecuteWithdrawCommand(object obj)
        {
            float amount = float.Parse(obj.ToString());
            bool isValidSum = CardService.Card.Balance >= amount;
            if (isValidSum)
            {
                CardService.Card.Balance -= amount;
                cardRepository.Edit(CardService.Card);
                Transaction trans = new Transaction();
                trans.Amount = amount;
                trans.FromId = CardService.Card.CardId;
                trans.ToId = 1;
                trans.Timestamp = DateTime.Now;
                transactionRepository.Add(trans);
                _dialog.SuccessfulDialog("Successful withdraw");
                _dialog.ShowCustomDilog();
                if (CardService.Card.SendNotification)
                {
                    EmailSender.SendEmail(CardService.Card.Email, "Withdraw from card", $"<div>{amount} UAH were withdrawed from {CardService.Card.CardNumber}</div>");
                }
                NavigationService.NavigateTo<TransactionsViewModel>();
            }
            else
            {
                _dialog = new ConfirmationDialog();
                _dialog.ErrorDialog("Insufficient funds");
                _dialog.ShowCustomDilog();
            }
        }
    }
}
