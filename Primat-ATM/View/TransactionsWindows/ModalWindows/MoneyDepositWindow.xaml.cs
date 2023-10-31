using Primat_ATM.View.ConfirmationWindows;
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
        public MoneyDepositWindow(string hedline_cardNumber)
        {
            InitializeComponent();

            Headline_CardNumber.Text = hedline_cardNumber;
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Deposit(object sender, RoutedEventArgs e)
        {
            ConfirmationDialog confirmationDialog = new ConfirmationDialog();

            confirmationDialog.ConfirmationDilog("Deposit " + txtBoxAmount.Text + " UAH to your account?");
            bool yes = confirmationDialog.ShowCustomDilog();

            if (!yes)
            {
                return;
            }
            // money deposit

            // if the operation is successful
            confirmationDialog = new ConfirmationDialog();
            confirmationDialog.SuccessfulDialog("You have successfully deposited " + txtBoxAmount.Text + " UAH to your account.");
            confirmationDialog.ShowDialog();
        }
    }
}
