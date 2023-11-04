using Primat_ATM.Model;
using Primat_ATM.View.ConfirmationWindows;
using Primat_ATM.ViewModel.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Primat_ATM.View.TransactionsWindows.ModalWindows
{
    /// <summary>
    /// Логика взаимодействия для MoneyDepositWindow.xaml
    /// </summary>
    public partial class MoneyDepositWindow : Window
    {
        public MoneyDepositWindow()
        {
            InitializeComponent();
        }
        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
