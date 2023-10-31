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

namespace Primat_ATM.View.TransactionsWindows.MoneyWithdrawalWindows.ModalWindows
{
    /// <summary>
    /// Логика взаимодействия для OtherWithdrawalWindow.xaml
    /// </summary>
    public partial class OtherWithdrawalWindow : Window
    {
        Button parentButton;

        public OtherWithdrawalWindow(string headline_cardNumber, Button parentButton)
        {
            this.parentButton = parentButton;

            InitializeComponent();

            Headline_CardNumber.Text = headline_cardNumber;
        }

        private void Cancel(object sender,  RoutedEventArgs e)
        {
            parentButton.Tag = null;
            this.Close();
        }

        private void withdraw(object sender, RoutedEventArgs e)
        {
            Button btnClick = (Button)sender;
            parentButton.Tag = txtBoxAmount.Text;

            this.Close();
        }
    }
}
