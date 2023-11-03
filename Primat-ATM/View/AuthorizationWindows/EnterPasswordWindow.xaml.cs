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
    /// Логика взаимодействия для EnterPassword.xaml
    /// </summary>
    public partial class EnterPasswordWindow : Window
    {
        private string card_number;
        private bool isCorrectPassword;
        public EnterPasswordWindow()
        {
/*            this.card_number = card_number;
            isCorrectPassword = false;*/

            InitializeComponent();
        }

/*        private void CheckTheLogin(object sender, RoutedEventArgs e)
        {
            isCorrectPassword = true;
            this.Close();
        }

        public bool ShowCustomDialog()
        {
            ShowDialog();

            return isCorrectPassword;
        }*/
    }
}
