using Primat_ATM.Model;
using Primat_ATM.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Primat_ATM.ViewModel
{
    public class TestViewModel
    {
        private Card card;
        private ICardRepository cardRepository;
        private ITransactionRepository transactionRepository;
        public TestViewModel()
        {
            cardRepository = new CardRepository();
            transactionRepository = new TransactionRepository();
            card = new Card();
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            GetCardIdCommand = new ViewModelCommand(ExecuteGetCardIdCommand);
        }

        public ICommand LoginCommand { get; }
        public ICommand GetCardIdCommand { get; }

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

        private void ExecuteLoginCommand(object obj)
        {
            var isValidCard = cardRepository.AuthenticateCard(new NetworkCredential(CardNumber, Pin));
            if (isValidCard)
            {
                MessageBox.Show("Authed");
            }
            else
            {
                MessageBox.Show("Failed");
            }
        }

        private bool CanExecuteLoginCommand(object obj)
        {
            bool validData = false;
            if (!string.IsNullOrWhiteSpace(CardNumber))
            {
                validData = true;
            }
            return validData;
        }

        private void ExecuteGetCardIdCommand(object obj)
        {
            Card card = cardRepository.GetById(Int32.Parse(CardNumber));
            MessageBox.Show("CardId: " + card.CardId + "; Card num: " + card.CardNumber + "; Balance: " + card.Balance);
            //return card;
        }
    }
}
