using Primat_ATM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primat_ATM.ViewModel.Services
{

    public interface ICardService
    {
        public Card Card { get; set; }
        public void Authenticate(Card card);
    }
    public class CardService : ICardService
    {
        public Card Card { get; set; } = new Card();

        public void Authenticate(Card card)
        {
            Card = card;
        }
    }
}
