using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primat_ATM.ViewModel.Services
{
    public class ViewModelLocator
    {
        private readonly IServiceProvider _provider;
        public ViewModelLocator(IServiceProvider provider)
        {
            _provider = provider;
        }

        public MainViewModel MainViewModel => _provider.GetRequiredService<MainViewModel>();
        public LoginViewModel LoginViewModel => _provider.GetRequiredService<LoginViewModel>();
        public SettingsViewModel SettingsViewModel => _provider.GetRequiredService<SettingsViewModel>();
        public DepositViewModel DepositViewModel => _provider.GetRequiredService<DepositViewModel>();
        public TransferViewModel TransferViewModel => _provider.GetRequiredService<TransferViewModel>();
        public WithdrawalViewModel WithdrawalViewModel => _provider.GetRequiredService<WithdrawalViewModel>();
    }
}
