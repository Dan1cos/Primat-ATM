using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primat_ATM.Model
{
    public class Transaction : INotifyPropertyChanged
    {
        private int transactionId;
        private DateTime timestamp;
        private int fromId;
        private int toId;
        private float amount;

        public int TransactionId
        {
            get
            {
                return transactionId;
            }
            set
            {
                transactionId = value;
                OnPropertyChanged("TransactionId");
            }
        }

        public DateTime Timestamp
        {
            get
            {
                return timestamp;
            }
            set
            {
                timestamp = value;
                OnPropertyChanged("Timestamp");
            }
        }

        public int FromId
        {
            get
            {
                return fromId;
            }
            set
            {
                fromId = value;
                OnPropertyChanged("FromId");
            }
        }

        public int ToId
        {
            get
            {
                return toId;
            }
            set
            {
                toId = value;
                OnPropertyChanged("ToId");
            }
        }

        public float Amount
        {
            get
            {
                return amount;
            }
            set
            {
                amount = value;
                OnPropertyChanged("Amount");
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
