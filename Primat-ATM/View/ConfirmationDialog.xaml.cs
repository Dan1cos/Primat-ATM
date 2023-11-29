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
    /// Логика взаимодействия для ConfirmationDialog.xaml
    /// </summary>
    public partial class ConfirmationDialog : Window

    {
        private bool yes;

        public ConfirmationDialog()
        {
            InitializeComponent();
            init();
        }

        private void init(string txt = "Confirm the action?", string bckg = "ConfirmationBlue", string cancle_bckg = "ButtonCancelGray",
            string confirm_bckg = "ButtonYesSaveGreen", string txt_cancel = "Cancel", string txt_confirm ="Confirm")
        {
            Background = (SolidColorBrush)Resources[bckg];
            Cancelbtn.Background = (SolidColorBrush)Resources[cancle_bckg];
            Confirmbtn.Background = (SolidColorBrush)Resources[confirm_bckg];
            SomeTxt.Text = txt;
            Cancelbtn.Content = txt_cancel;
            Confirmbtn.Content = txt_confirm;
        }

        public void setText_q(string txt)
        {
            SomeTxt.Text = txt;
        }

        public void ConfirmationDilog(string txt)
        {
            Title = "ConfirmationDilog";
            init(txt);
        }

        public void WarningDialog(string _txt)
        {
            Title = "WarningDialog";
            init(txt:_txt, bckg: "WarningYellow", confirm_bckg: "ButtonYesSaveGreen", txt_confirm:"Okay");
        }

        public void ErrorDialog(string _txt)
        {
            Title = "ErrorDialog";
            init(txt: _txt, bckg: "ErrorRed", confirm_bckg: "ButtonDeleteRed", txt_confirm: "Okay");
        }

        public void SuccessfulDialog(string _txt)
        {
            Title = "SuccessfulDialog";
            init(txt: _txt, bckg: "SuccessfulGrean", confirm_bckg: "ButtonYesSaveGreen", txt_confirm: "Okay");
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Confirm(object sender, RoutedEventArgs e)
        {
            yes = true;
            Cancel(sender, e);
        }

        public bool ShowCustomDilog()
        {
            this.ShowDialog();

            return yes;
        }
    }
}