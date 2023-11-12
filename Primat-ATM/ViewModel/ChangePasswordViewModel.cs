using Primat_ATM.Model;
using Primat_ATM.Repository;
using Primat_ATM.View;
using Primat_ATM.ViewModel.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Primat_ATM.ViewModel
{
    public class ChangePasswordViewModel: ViewModelBase
    {
        Card _card;
        private string _repeatNewPin;
        //private string _confirmMessage;
        private string _errorMessage;
        private INavigationService _navigationService;
        private ICardRepository CardRepository;
        public ICardService CardService { get; private set; }
        public RelayCommand NavigateCancelCommand { get; set; }
        public ICommand ChangePasswordCommand { get; }
        private ConfirmationDialog _confirmPin;
        public ChangePasswordViewModel(INavigationService navigationService, ICardService cardService)
        {
            CardRepository = new CardRepository();
            NavigationService = navigationService;
            CardService = cardService;
            _card = new Card();
            //_confirmMessage = "Are you sure you want to change the password?";
            _confirmPin = new ConfirmationDialog();
            NavigateCancelCommand = new RelayCommand(o => { NavigationService.NavigateTo<SettingsViewModel>(); }, o => true);
            ChangePasswordCommand = new RelayCommand(ExecuteChangePasswordCommand, CanExecuteChangePasswordCommand);
        }

        public string NewPin
        {
            get => _card.Pin;
            set => _card.Pin = value;
        }
        public string RepeatNewPin
        {
            get => _repeatNewPin;
            set => _repeatNewPin = value;
        }
        //public string ConfirmMessage
        //{
        //    get => _confirmMessage;
        //    set
        //    {
        //        _confirmMessage = value;
        //        OnPropertyChanged("ConfirmMessage");
        //    }
        //}
        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged("ErrorMessage");
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
        private void ExecuteChangePasswordCommand(object obj)
        {
            _confirmPin.ConfirmationDilog("Are you sure you want to change the password?");
            if (_confirmPin.ShowCustomDilog())
            {
                if (CanExecuteChangePasswordCommand(obj))
                {
                    CardService.Card.Pin = _card.Pin;
                    CardRepository.Edit(CardService.Card);
                    NavigationService.NavigateTo<SettingsViewModel>();
                }
                else
                {
                    ErrorMessage = "Password is either empty or is not 4 digits";
                }
            }
            
        }
        private bool CanExecuteChangePasswordCommand(object obj) {
            return !string.IsNullOrWhiteSpace(NewPin) && NewPin.Length == 4 && NewPin.All(char.IsDigit) &&
                !string.IsNullOrWhiteSpace(RepeatNewPin) && RepeatNewPin.Length == 4 && RepeatNewPin.All(char.IsDigit) &&
                RepeatNewPin.Equals(NewPin)
                ? true : false;
        }
    }
}
