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

namespace Primat_ATM.View
{
    /// <summary>
    /// Логика взаимодействия для CardTransactions.xaml
    /// </summary>
    public partial class TransactionsWindow : Window
    {
        private string card_number;
        private string name;
        public TransactionsWindow(string card_number)
        {
            this.card_number = card_number;
            this.name = "Maks";

            InitializeComponent();

            HeadLine_CardNumber.Text = HeadLine_CardNumber.Text + card_number;
            HeadLine_Name.Text = "Hello, " + name + ", choose an operation";
        }

        private void MoneyWithdrawal(object sender, RoutedEventArgs e)
        {
            MoneyWithdrawalWindow moneyWithdrawal = new MoneyWithdrawalWindow(HeadLine_CardNumber.Text);
            moneyWithdrawal.ShowDialog();
        }

        private void Balance(object sender, RoutedEventArgs e)
        {

        }

        private void MoneyDeposit(object sender, RoutedEventArgs e)
        {

        }

        private void Statement(object sender, RoutedEventArgs e)
        {

        }

        private void TransferMoney(object sender, RoutedEventArgs e)
        {

        }

        private void CardOperations(object sender, RoutedEventArgs e)
        {
            CardOperationsWindow cardOperations = new CardOperationsWindow(HeadLine_CardNumber.Text);
            cardOperations.ShowDialog();
        }

        private void EndSession(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();

            foreach (Window window in Application.Current.Windows)
            {
                if (window != mainWindow)
                {
                    window.Close();
                }
            }

            mainWindow.Show();
        }
    }
}
