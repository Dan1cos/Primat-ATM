using Primat_ATM.View;
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
            RegisterMapping<MainViewModel, ContainerWindow>();
            /*RegisterMapping<SettingsViewModel, CardOperationsWindow>();
            RegisterMapping<DepositViewModel, MoneyDepositWindow>();*/
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
