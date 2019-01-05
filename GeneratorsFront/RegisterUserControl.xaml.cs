using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace CryptoDesktopApplication.GeneratorsFront
{
    /// <summary>
    /// Interaction logic for RegisterUserControl.xaml
    /// </summary>
    public partial class RegisterUserControl : UserControl
    {

        public RegisterUserControl()
        {
            InitializeComponent();
        }

        private void Clear_lfsr(object Sender, RoutedEventArgs e)
        {
            lfsrTxtBox.Text = string.Empty;
        }


        private void lfsr_TextChanged(object sender, TextChangedEventArgs e)
        {
            rCounter.Content = lfsrTxtBox.Text.Length;
        }

        private void setRegister_Click(object sender, RoutedEventArgs e)
        {
            var input = lfsrTxtBox.Text;
            if (input.Length < 2)
            {
                MessageBox.Show("Rejestr musi mieć co najmniej 2 bity!");
                return;
            }
            rState.Content = input;
            rCurrentCounter.Content = input.Length;
        }

        #region InputValidation

        private static readonly Regex _digitsOnlyRegex = new Regex("[^0-9.-]+");
        private static bool IsTextAllowed(string text)
        {
            return _digitsOnlyRegex.IsMatch(text);
        }

        private static readonly Regex _binaryStringOnlyRegex = new Regex("[^0-1]+");
        private static bool IsBinaryString(string text)
        {
            return _binaryStringOnlyRegex.IsMatch(text);
        }

        private void TextBoxPasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(String)))
            {
                String text = (String)e.DataObject.GetData(typeof(String));
                if (IsTextAllowed(text))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }
        private void BinaryStringPasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(String)))
            {
                String text = (String)e.DataObject.GetData(typeof(String));
                if (IsBinaryString(text))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex rgx = new Regex("[^0-9]+");
            e.Handled = rgx.IsMatch(e.Text);
        }

        private void BinaryStringValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-1]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        #endregion
    }
}
