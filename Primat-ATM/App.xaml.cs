using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Primat_ATM.View;
using Primat_ATM.ViewModel;
using Primat_ATM.ViewModel.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Primat_ATM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IServiceCollection services = new ServiceCollection();
        private readonly IServiceProvider _serviceProvider;
        public App()
        {

            services.AddSingleton<LoginViewModel>();
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<TransactionsViewModel>();
            services.AddSingleton<WithdrawViewModel>();
            services.AddSingleton<DepositViewModel>();
            services.AddSingleton<TransferViewModel>();
            services.AddSingleton<SettingsViewModel>();
            services.AddSingleton<BalanceViewModel>();
            services.AddSingleton<StatementViewModel>();
            

            services.AddSingleton<ViewModelLocator>();
            services.AddSingleton<WindowMapper>();
            services.AddSingleton<IWindowManager, WindowManager>();
            services.AddSingleton<ICardService, CardService>();
            services.AddSingleton<INavigationService, NavigationService>();

            services.AddSingleton<Func<Type, ViewModelBase>>(serviceProvider => viewModelType => (ViewModelBase)serviceProvider.GetRequiredService(viewModelType));

            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {

            var windowManager = _serviceProvider.GetRequiredService<IWindowManager>();
            windowManager.ShowWindow(_serviceProvider.GetRequiredService<LoginViewModel>());
            base.OnStartup(e);
        }
    }
}
