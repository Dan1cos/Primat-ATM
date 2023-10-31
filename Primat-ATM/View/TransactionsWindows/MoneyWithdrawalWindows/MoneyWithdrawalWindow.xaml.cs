using Primat_ATM.View.ConfirmationWindows;
using Primat_ATM.View.TransactionsWindows.MoneyWithdrawalWindows.ModalWindows;
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
    /// Логика взаимодействия для MoneyWithdrawalWindow.xaml
    /// </summary>
    public partial class MoneyWithdrawalWindow : Window
    {
        public MoneyWithdrawalWindow(string hedline_card)
        {
            InitializeComponent();

            HeadLine_CardNumber.Text = hedline_card;
        }

        private void OtherClick(object sender, RoutedEventArgs e)
        {
            OtherWithdrawalWindow otherWithdrawal = new OtherWithdrawalWindow(HeadLine_CardNumber.Text, (Button)sender);
            otherWithdrawal.ShowDialog();

            if (((Button)sender).Tag != null)
                withdraw(sender, e);
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void withdraw(object sender, RoutedEventArgs e)
        {
            Button btnClick = (Button)sender;

            ConfirmationDialog confirmationDialog = new ConfirmationDialog();

            confirmationDialog.ConfirmationDilog("Withdraw " + btnClick.Tag + " UAH?");
            bool yes = confirmationDialog.ShowCustomDilog();

            if (!yes)
            {
                return;
            }
            // withdraws money

            // if the operation is successful
            confirmationDialog = new ConfirmationDialog();
            confirmationDialog.SuccessfulDialog("You have successfully withdrawn " + btnClick.Tag + " UAH.");
            confirmationDialog.ShowDialog();
        }
    }
}
