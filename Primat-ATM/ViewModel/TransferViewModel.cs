﻿using Primat_ATM.ViewModel.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Primat_ATM.Model;
using Primat_ATM.ViewModel.Services;

namespace Primat_ATM.ViewModel
{
    public class TransferViewModel: ViewModelBase
    {
        private INavigationService _navigationService;
        public RelayCommand NavigateCancelCommand { get; set; }
        public TransferViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;

            NavigateCancelCommand = new RelayCommand(o => { NavigationService.NavigateTo<TransactionsViewModel>(); }, o => true);
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
    }
}
