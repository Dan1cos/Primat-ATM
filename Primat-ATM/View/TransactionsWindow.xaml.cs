﻿using Primat_ATM.View.TransactionsWindows.ModalWindows;
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
        public TransactionsWindow()
        {
            InitializeComponent();
        }
        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
