using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primat_ATM.ViewModel
{
    struct RTransaction
    {
        public string To { get; set; }
        public string From { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }

        public RTransaction(string to, string from, double amount, DateTime date)
        {
            To = to;
            From = from;
            Amount = amount;
            Date = date;
        }
    }
}
