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
            
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
