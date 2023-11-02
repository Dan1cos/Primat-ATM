using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primat_ATM.Model
{
    public class Card : INotifyPropertyChanged
    {
        private int cardId;
        private string cardNumber;
        private float balance;
        private string email;
        private string pin;
        private bool sendNotification;
        public int CardId
        {
            get
            {
                return cardId;
            }
            set
            {
                cardId = value;
                OnPropertyChanged("CardId");
            }
        }

        public string CardNumber
        {
            get
            {
                return cardNumber;
            }
            set
            {
                cardNumber = value;
                OnPropertyChanged("CardNumber");
            }
        }

        public float Balance
        {
            get
            {
                return balance;
            }
            set
            {
                balance = value;
                OnPropertyChanged("Balance");
            }
        }

        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }

        public string Pin
        {
            get
            {
                return pin;
            }
            set
            {
                pin = value;
                OnPropertyChanged("Pin");
            }
        }

        public bool SendNotification
        {
            get
            {
                return sendNotification;
            }
            set
            {
                sendNotification = value;
                OnPropertyChanged("SendNotification");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}