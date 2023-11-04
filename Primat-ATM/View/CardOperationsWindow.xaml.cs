﻿using Primat_ATM.View.ConfirmationWindows;
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
        public CardOperationsWindow()
        {
            InitializeComponent();
        }
        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
