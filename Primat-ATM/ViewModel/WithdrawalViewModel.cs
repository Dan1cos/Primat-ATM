using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Primat_ATM.Model;
using Primat_ATM.ViewModel.Services;

namespace Primat_ATM.ViewModel
{
    public class WithdrawalViewModel: ViewModelBase
    {
        ICardService cardRepository;
        ITransactionRepository transactionRepository;
        IWindowManager windowManager;
        public WithdrawalViewModel()
        {

        }
    }
}
