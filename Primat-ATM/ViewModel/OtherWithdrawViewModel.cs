﻿using Primat_ATM.ViewModel.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primat_ATM.ViewModel
{
    public class OtherWithdrawViewModel: ViewModelBase
    {
        private INavigationService _navigationService;
        public RelayCommand NavigateCancelCommand { get; set; }
        public OtherWithdrawViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;

            NavigateCancelCommand = new RelayCommand(o => { NavigationService.NavigateTo<WithdrawViewModel>(); }, o => true);
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