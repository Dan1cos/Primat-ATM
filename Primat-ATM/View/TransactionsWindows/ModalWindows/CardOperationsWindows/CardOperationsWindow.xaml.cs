using Primat_ATM.View.ConfirmationWindows;
using Primat_ATM.View.TransactionsWindows.ModalWindows.CardOperationsWindows.ModalWindows;
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
    /// Логика взаимодействия для CardOperations.xaml
    /// </summary>
    public partial class CardOperationsWindow : Window
    {
        public CardOperationsWindow(string hedline_card)
        {
            InitializeComponent();

            HeadLine_CardNumber.Text = hedline_card;
        }

        private void ChangePIN(object sender, RoutedEventArgs e)
        {
            EnterPasswordWindow enterPassword = new EnterPasswordWindow(HeadLine_CardNumber.Text);
            bool isCorrectPassword = enterPassword.ShowCustomDialog();

            if (isCorrectPassword)
            {
                ChangePasswordWindow changePassword = new ChangePasswordWindow(HeadLine_CardNumber.Text);
                changePassword.ShowDialog();
            }
            else
            {
                ConfirmationDialog confirmationDialog = new ConfirmationDialog();
                confirmationDialog.ErrorDialog("Incorrect PIN!");
                confirmationDialog.ShowDialog();
            }
        }

        private void ChangeEmail(object sender, RoutedEventArgs e)
        {
            EnterPasswordWindow enterPassword = new EnterPasswordWindow(HeadLine_CardNumber.Text);
            bool isCorrectPassword = enterPassword.ShowCustomDialog();

            if (isCorrectPassword)
            {
                ChangeEmailWindow changeEmail = new ChangeEmailWindow(HeadLine_CardNumber.Text);
                changeEmail.ShowDialog();
            }
            else
            {
                ConfirmationDialog confirmationDialog = new ConfirmationDialog();
                confirmationDialog.ErrorDialog("Incorrect PIN!");
                confirmationDialog.ShowDialog();
            }
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
