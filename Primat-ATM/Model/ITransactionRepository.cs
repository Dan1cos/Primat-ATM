using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primat_ATM.Model
{
    interface ITransactionRepository
    {

        void Add(Transaction transaction);
        List<Transaction> GetByFromId(int fromId);
        List<Transaction> GetByToId(int toId);
        Transaction GetByTransactionId(int transactionId);

    }
}
