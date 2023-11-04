using Primat_ATM.View;
using Primat_ATM.View.TransactionsWindows.ModalWindows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Primat_ATM.ViewModel.Services
{
    public class WindowMapper
    {
        private readonly Dictionary<Type, Type> _mappings = new();

        public WindowMapper()
        {
            RegisterMapping<LoginViewModel, MainWindow>();
            RegisterMapping<MainViewModel, TransactionsWindow>();
            RegisterMapping<SettingsViewModel, CardOperationsWindow>();
            RegisterMapping<DepositViewModel, MoneyDepositWindow>();
            RegisterMapping<TransferViewModel, TransferMoneyWindow>();
            RegisterMapping<WithdrawalViewModel, MoneyWithdrawalWindow>();
        }

        public void RegisterMapping<TViewModel, TWindow>() where TViewModel: ViewModelBase where TWindow: Window
        {
            _mappings[typeof(TViewModel)] = typeof(TWindow);
        }

        public Type GetWindowTypeForViewModel(Type viewModelType)
        {
            _mappings.TryGetValue(viewModelType, out var windowType);
            return windowType;
        }
    }
}
