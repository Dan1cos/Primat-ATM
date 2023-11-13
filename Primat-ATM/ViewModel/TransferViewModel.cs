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
    public class TransferViewModel: ViewModelBase
    {
        private string _cardTo;
        private float _amountTo;

        private INavigationService _navigationService;
        public RelayCommand NavigateCancelCommand { get; set; }
        public RelayCommand TransferCommand { get; set; }
        private ICardRepository cardRepository;
        private ITransactionRepository transactionRepository;
        private string errorMessage;
        public ICardService CardService { get; set; }
        public TransferViewModel(INavigationService navigationService, ICardService cardService)
        {
            NavigationService = navigationService;
            cardRepository = new CardRepository();
            transactionRepository = new TransactionRepository();
            CardService = cardService;

            NavigateCancelCommand = new RelayCommand(o => { NavigationService.NavigateTo<TransactionsViewModel>(); }, o => true);
            TransferCommand = new RelayCommand(ExecuteTransferCommand, CanExecuteTransferCommand);
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

        public string CardNumber
        {
            get => _cardTo;
            set => _cardTo = value;
        }

        public float Amount
        {
            get => _amountTo;
            set => _amountTo = value;
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

        private void ExecuteTransferCommand(object obj)
        {
            bool isCardReal = cardRepository.GetByCardNumber(CardNumber) != null;
            if (isCardReal)
            {
                bool isValidSum = CardService.Card.Balance>=Amount;
                if (isValidSum)
                {
                    var cardTo = cardRepository.GetByCardNumber(CardNumber);
                    cardTo.Balance += Amount;
                    CardService.Card.Balance -= Amount;
                    cardRepository.Edit(cardTo);
                    cardRepository.Edit(CardService.Card);
                    Transaction trans = new Transaction();
                    trans.Amount = Amount;
                    trans.FromId = CardService.Card.CardId;
                    trans.ToId = cardTo.CardId;
                    trans.Timestamp = DateTime.Now;
                    transactionRepository.Add(trans);
                    ErrorMessage = "";
                    MessageBox.Show("Success");
                    if (CardService.Card.SendNotification)
                    {
                        EmailSender.SendEmail(CardService.Card.Email, "Transfer from card", $"<div>{Amount} UAH were transfered to {cardTo.CardNumber} from {CardService.Card.CardNumber}</div>");
                    }
                    if (cardTo.SendNotification)
                    {
                        EmailSender.SendEmail(cardTo.Email, "Transfer to card", $"<div>{Amount} UAH were transfered to {cardTo.CardNumber} from {CardService.Card.CardNumber}</div>");
                    }    
                    NavigationService.NavigateTo<TransactionsViewModel>();
                }
                else
                {
                    ErrorMessage = "You don't have enough money";
                }
            }
            else
            {
                ErrorMessage = "Transfered card is unreal";
            }
        }

        private bool CanExecuteTransferCommand(object obj)
        {
            bool validData = false;
            if (!string.IsNullOrWhiteSpace(CardNumber) && CardNumber.Length == 16 && CardNumber.All(char.IsDigit) && !float.IsNaN(Amount) && !float.IsNegative(Amount) && Amount!=0)
            {
                validData = true;
            }
            return validData;
        }
    }
}
