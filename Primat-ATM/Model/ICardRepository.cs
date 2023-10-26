using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Primat_ATM.Model
{
    interface ICardRepository
    {
        bool AuthenticateCard(NetworkCredential credential);
        void Add(Card card);
        void Edit(Card card);
        void Remove(int id);
        Card GetById(int id);
        Card GetByCardNumber(string cardNumber);

    }
}
