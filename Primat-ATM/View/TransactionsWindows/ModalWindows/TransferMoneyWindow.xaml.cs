﻿using Primat_ATM.View.ConfirmationWindows;
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
    /// Логика взаимодействия для TransferMoneyWindow.xaml
    /// </summary>
    public partial class TransferMoneyWindow : Window
    {
        public TransferMoneyWindow(string hedline_card)
        {
            InitializeComponent();

            HeadLine_CardNumber.Text = hedline_card;
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Transfer(object sender, RoutedEventArgs e)
        {
            ConfirmationDialog confirmationDialog = new ConfirmationDialog();
            confirmationDialog.Height = confirmationDialog.Height + 20;
            confirmationDialog.SomeTxt.TextAlignment = TextAlignment.Left;

            confirmationDialog.ConfirmationDilog("Recipient's card: " + txtBoxCardNumber.Text + '\n' +
                "Amount: " + txtBoxAmount.Text + '\n' +
                "Transfer money?");

            bool yes = confirmationDialog.ShowCustomDilog();

            if (!yes)
            {
                return;
            }
            // money deposit

            // if the operation is successful
            confirmationDialog = new ConfirmationDialog();
            confirmationDialog.SuccessfulDialog("You have successfully transferred " + txtBoxAmount.Text + 
                "\nUAH to the card " + txtBoxCardNumber.Text + '.');
            confirmationDialog.ShowDialog();
        }
    }
}
