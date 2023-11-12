using Primat_ATM.Model;
using Primat_ATM.Repository;
using Primat_ATM.ViewModel.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primat_ATM.ViewModel
{
    public class StatementViewModel: ViewModelBase
    {
        private int _selectedComboBoxId = 0;
        private INavigationService _navigationService;
        private ITransactionRepository transactionRepository;
        private IList<Transaction> _transactionList;
        public RelayCommand NavigateCancelCommand { get; set; }
        public ICardService CardService { get; set; }
        public StatementViewModel(INavigationService navigationService, ICardService cardService)
        {
            NavigationService = navigationService;
            CardService = cardService;
            transactionRepository = new TransactionRepository();
            TransactionList = transactionRepository.GetByToId(CardService.Card.CardId);

            NavigateCancelCommand = new RelayCommand(o => { NavigationService.NavigateTo<TransactionsViewModel>(); }, o => true);
        }

        public IList<Transaction> TransactionList
        {
            get => _transactionList;
            set
            {
                _transactionList = value;
                OnPropertyChanged();
            }
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

        public int SelectedComboBoxId
        {
            get => _selectedComboBoxId;
            set
            {
                _selectedComboBoxId = value;
                switch (_selectedComboBoxId)
                {
                    case 1:
                        TransactionList = transactionRepository.GetByFromId(CardService.Card.CardId);
                        break;
                    default:
                        TransactionList = transactionRepository.GetByToId(CardService.Card.CardId);
                        break;
                }
            }
        }
    }
}
