using Primat_ATM.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Primat_ATM.View.ConfirmationWindows;

namespace Primat_ATM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Send(object sender, RoutedEventArgs e)
        {
            string card_number = txtBoxCardNumber.Text;
            EnterPasswordWindow popup = new EnterPasswordWindow(card_number);
            bool isCorrectPassword = popup.ShowCustomDialog();

            if (isCorrectPassword)
            {
                TransactionsWindow transactions = new TransactionsWindow(card_number);
                this.Close();

                transactions.Show();
            } 
            else
            {
                ConfirmationDialog errorDialog = new ConfirmationDialog();
                errorDialog.ErrorDialog("Wrong password!");
                errorDialog.ShowDialog();
            }
        }
    }
}
