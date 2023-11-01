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

namespace Primat_ATM.View.TransactionsWindows.ModalWindows.CardOperationsWindows.ModalWindows
{
    /// <summary>
    /// Логика взаимодействия для ChangePasswordWindow.xaml
    /// </summary>
    public partial class ChangePasswordWindow : Window
    {
        public ChangePasswordWindow(string card_number)
        {
            InitializeComponent();

            Headline_CardNumber.Text = card_number;
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Change(object sender, RoutedEventArgs e)
        {
            ConfirmationDialog confirmationDialog = new ConfirmationDialog();

            if (txtBoxNewPIN.Text != txtBoxRepeatNewPIN.Text)
            {
                confirmationDialog.WarningDialog("The PIN was repeated incorrectly!");
                confirmationDialog.ShowDialog();
                return;
            }
            confirmationDialog.ConfirmationDilog("Change PIN?");
            bool yes = confirmationDialog.ShowCustomDilog();

            if (yes)
            {
                confirmationDialog = new ConfirmationDialog();
                confirmationDialog.SuccessfulDialog("PIN has been successfully changed.");
                confirmationDialog.ShowDialog();
            }

            this.Close();
        }
    }
}
