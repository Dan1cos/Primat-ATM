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
using System.Text.RegularExpressions;

namespace Primat_ATM.ViewModel
{
    public class ChangeEmailViewModel:ViewModelBase
    {
        private string _email;
        private const string _match = @"([a-zA-Z0-9.]+)\@[a-zA-Z0-9.]+\.[a-zA-Z]{2,}$";
        //private string _confirmMessage;
        private string _errorMessage;
        private INavigationService _navigationService;
        private ICardRepository CardRepository;
        public ICardService CardService { get; }
        private Regex regex;
        public RelayCommand NavigateCancelCommand { get; set; }
        public RelayCommand ChangeEmailCommand { get; set; }
        private ConfirmationDialog _confirmEmail;
        public ChangeEmailViewModel(INavigationService navigationService, ICardService cardService)
        {
            CardRepository = new CardRepository();
            NavigationService = navigationService;
            CardService = cardService;
            regex = new Regex(_match);
            //_confirmMessage = "Are you sure you want to change the password?";
            _confirmEmail = new ConfirmationDialog();
            NavigateCancelCommand = new RelayCommand(o => { NavigationService.NavigateTo<SettingsViewModel>(); }, o => true);
            ChangeEmailCommand = new RelayCommand(ExecuteChangeEmailCommand, CanExecuteChangeEmailCommand);
        }
        public string Email
        {
            get => _email;
            set => _email = value;
        }
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

        public Regex Regex { get => regex;  }

        private void ExecuteChangeEmailCommand(object obj)
        {
            _confirmEmail.ConfirmationDilog("Are you sure you want to change the email?");
            if (_confirmEmail.ShowCustomDilog())
            {
                if (CanExecuteChangeEmailCommand(obj))
                {
                    ErrorMessage = "";
                    CardService.Card.Email = _email;
                    CardRepository.Edit(CardService.Card);
                    NavigationService.NavigateTo<SettingsViewModel>();
                }
                else
                {
                    ErrorMessage = "Incorrect email";
                }
            }

        }
        private bool CanExecuteChangeEmailCommand(object obj)
        {
            return !string.IsNullOrWhiteSpace(Email) && Email.Length <= 45 && Regex.Match(Email).Success;
        }
    }
}
