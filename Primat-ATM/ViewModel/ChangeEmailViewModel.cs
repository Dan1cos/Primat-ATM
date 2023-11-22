using Primat_ATM.Model;
using Primat_ATM.Repository;
using Primat_ATM.View;
using Primat_ATM.ViewModel.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Text.RegularExpressions;

namespace Primat_ATM.ViewModel
{
    public class ChangeEmailViewModel:ViewModelBase
    {
        private string _email;
        private const string _match = @"[-A-Za-z0-9!#$*+=/?^_{|}~]+(?:\.[-A-Za-z0-9!#$*+/=?^_{|}~]+)*\@(?:[A-Za-z0-9](?:[-A-Za-z0-9]*[A-Za-z0-9])?\.)+[A-Za-z0-9](?:[-A-Za-z0-9]*[A-Za-z0-9])?";
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
                    if (CardService.Card.SendNotification)
                    {
                        EmailSender.SendEmail(CardService.Card.Email, "Email change", "<div>Email in Primat ATM was changed to this email</div>");
                    }
                    NavigationService.NavigateTo<SettingsViewModel>();
                }
                else
                {
                    ErrorMessage = "Incorrect email";
                }
            }
            _confirmEmail = new ConfirmationDialog();
        }
        private bool CanExecuteChangeEmailCommand(object obj)
        {
            return !string.IsNullOrWhiteSpace(Email) && Email.Length <= 45 && regex.Match(Email, _match).Success;
        }
    }
}
