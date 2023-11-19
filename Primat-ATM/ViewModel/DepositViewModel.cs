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
    public class DepositViewModel: ViewModelBase
    {
        private float _amount;
        private INavigationService _navigationService;
        public RelayCommand NavigateCancelCommand { get; set; }
        public RelayCommand DepositCommand { get; set; }
        public ICardService CardService { get; set; }
        private ICardRepository cardRepository;
        private ITransactionRepository transactionRepository;
        private ConfirmationDialog _dialog;
        public DepositViewModel(INavigationService navigationService, ICardService cardService)
        {
            NavigationService = navigationService;
            CardService = cardService;
            cardRepository = new CardRepository();
            transactionRepository = new TransactionRepository();
            _dialog = new ConfirmationDialog();

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
            _dialog.SuccessfulDialog("Successful deposit");
            _dialog.ShowCustomDilog();
            if (CardService.Card.SendNotification)
            {
                EmailSender.SendEmail(CardService.Card.Email, "Deposit to card", $"<div>{Amount} UAH were deposited to {CardService.Card.CardNumber}</div>");
            }
            NavigationService.NavigateTo<TransactionsViewModel>();
        }

        private bool CanExecuteDepositCommand(object obj)
        {
            return !float.IsNaN(Amount) && !float.IsNegative(Amount) && Amount != 0;
        }
    }
}
